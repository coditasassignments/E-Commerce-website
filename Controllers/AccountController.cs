
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Website.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
