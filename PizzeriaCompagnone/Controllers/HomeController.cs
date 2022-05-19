using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Models;
using System.Diagnostics;

namespace PizzeriaCompagnone.Controllers
{
    public class HomeController : Controller
    {


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