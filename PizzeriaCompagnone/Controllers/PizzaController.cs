using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Data;
using PizzeriaCompagnone.Models;
using PizzeriaCompagnone.Utils;

namespace PizzeriaCompagnone.Controllers
    
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizzas = DbPizza.GetPizzas();
            return View("HomePage", pizzas);
        }
        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            Pizza pizzaTrovata = null;
            
            pizzaTrovata = TrovaId(id);

            if (pizzaTrovata != null)
            {
                return View("Dettagli", pizzaTrovata);
            }
            else
            {
                return NotFound("il post con id " + id + " non è stato trovato!");
            }


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("NuovoPost") ;
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("NuovoPost", nuovaPizza);
            }
            using (PizzaContext db = new PizzaContext())
            {
                Pizza creoLaPizza = new Pizza(nuovaPizza.Title, nuovaPizza.Ingredienti, nuovaPizza.Image, nuovaPizza.Image2, nuovaPizza.Prezzo);
                db.Pizze.Add(creoLaPizza);
                db.SaveChanges();
            }
            //Se il mio modello e´corretto 
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Aggiorna()
        {
            return View("Aggiorna");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Aggiorna", model);
            }
            Pizza pizzaOriginale = TrovaId(id);
            if(pizzaOriginale != null)
            {
                pizzaOriginale.id = model.id;
                pizzaOriginale.Title = model.Title;
                pizzaOriginale.Ingredienti = model.Ingredienti;
                pizzaOriginale.Image = model.Image;
                pizzaOriginale.Image2 = model.Image2;
                pizzaOriginale.Prezzo = model.Prezzo;
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound(); 
            }
        }
        //Metodo per eliminare la nostra pizza

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(int id)
        {
            int indicePizzaDaRimuovere = -1;
            List<Pizza> listaPizza = DbPizza.GetPizzas();
            for(int i = 0; i < listaPizza.Count; i++)
            {
                if(listaPizza[i].id == id)
                {
                indicePizzaDaRimuovere = i;
                }
            }

            if(indicePizzaDaRimuovere != -1)
            {
                DbPizza.GetPizzas().RemoveAt(indicePizzaDaRimuovere);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        //Metodo per la ricerca dell´ íd
        private Pizza TrovaId(int id)
        {
            Pizza pizzaNuova = null;

            foreach (Pizza pizza in DbPizza.GetPizzas())
            {
                if (pizza.id == id)
                {
                    pizzaNuova = pizza;
                    break;
                }
            }
            return pizzaNuova;
        }
       
    }
}

