using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Data;
using PizzeriaCompagnone.Models;

namespace PizzeriaCompagnone.Controllers
{
    public class UtenteController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult registrazione()
        {
            return View("registrazione");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult registrazione(Utente nuovoUtente)
        {
            if (!ModelState.IsValid)
            {
                return View("login", nuovoUtente);
            }
            using (PizzaContext db = new PizzaContext())
            {
                Utente creoUtente = new Utente(nuovoUtente.nomeUtente, nuovoUtente.password);
                db.Add(creoUtente);
                db.SaveChanges();
            }
            //Se il mio modello e´corretto 
            return RedirectToAction("login", "Utente");

        }

    }
} 