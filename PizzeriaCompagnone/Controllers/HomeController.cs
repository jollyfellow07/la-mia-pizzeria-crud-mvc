using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Models;
using System.Diagnostics;

namespace PizzeriaCompagnone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult visualUtente()
        {

            return View("visualUtente");
        }

    }
}