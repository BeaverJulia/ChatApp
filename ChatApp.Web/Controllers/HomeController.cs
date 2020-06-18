using System.Diagnostics;
using ChatApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public IActionResult Index(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid) return View(signInViewModel);
            HttpContext.Session.SetString("UserName", signInViewModel.UserName);
            return RedirectToAction("Chat");
        }

        [HttpGet("Chat")]
        public IActionResult Chat()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Index");
            }

            return View("Chat", userName);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}