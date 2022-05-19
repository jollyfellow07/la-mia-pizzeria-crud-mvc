using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Data;
using PizzeriaCompagnone.Models;

namespace PizzeriaCompagnone.Controllers
{
    public class UtenteController : Controller
    {
        [HttpGet]
        public IActionResult login()
        {
            return View("login");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(Utente log)
        {
            using (PizzaContext db = new PizzaContext())
            {
                var data = db.Utenti.Where(s => s.nomeUtente == log.nomeUtente && s.password == log.password).FirstOrDefault();

                if (data != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                    return View("login");
                }

            }
        }
    }
} 