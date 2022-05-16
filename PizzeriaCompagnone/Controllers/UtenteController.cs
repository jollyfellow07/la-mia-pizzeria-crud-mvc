using Microsoft.AspNetCore.Mvc;

namespace PizzeriaCompagnone.Controllers
{
    public class UtenteController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
        public IActionResult registrazione()
        {
            return View();
        }


    }
}
