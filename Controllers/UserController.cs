﻿using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Models;
using E_Commerce_Website.Data;
using E_Commerce_Website.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Website.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Passwords do not match.");
                    return View(model);
                }

                var user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Password = PasswordHelper.HashPassword(model.Password)
                };
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");

            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Console.WriteLine("Entered Email: " + model.Email);
            Console.WriteLine("Entered Password: " + model.Password);

            if (ModelState.IsValid)
            {
                
                var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null && PasswordHelper.VerifyPassword(model.Password, user.Password))
                {
                    
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim("UserID", user.ID.ToString())
            };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                  
                    if (user.Email.Equals("admin@123.com", StringComparison.OrdinalIgnoreCase))
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }


                    return RedirectToAction("Index", "Product");
                }
                ModelState.AddModelError("", "Invalid email or password.");
            }

            return View(model);
        }




        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}

