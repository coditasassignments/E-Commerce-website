using Microsoft.AspNetCore.Mvc;
using E_Commerce_Website.Models;

namespace E_Commerce_Website.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
