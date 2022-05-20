﻿using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Data;
using PizzeriaCompagnone.Models;
using PizzeriaCompagnone.Utils;
using System.Linq;

namespace PizzeriaCompagnone.Controllers

{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizzaList = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {
                pizzaList = db.Pizze.ToList<Pizza>();

            }
            return View("HomePage", pizzaList);
        }
        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                try
                {
                    Pizza? pizzaTrovata = db.Pizze
                         .Where(pizza => pizza.id == id)
                         .FirstOrDefault();

                    return View("Dettagli", pizzaTrovata);

                }
                catch (InvalidOperationException ex)
                {
                    return NotFound("La pizza con id " + id + " non è stata trovata");
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }


            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Categoria> categorie = db.Categorie.ToList();

                CategoriaPizza model = new CategoriaPizza();
                model.Pizze = new Pizza();
                model.Categorie = categorie;
                return View("NuovoPost", model);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaPizza dati)
        {
            if (!ModelState.IsValid)
            {
                using(PizzaContext db = new PizzaContext())
                {
                    List<Categoria> categorie = db.Categorie.ToList();

                    dati.Categorie = categorie;
                    return View("NuovoPost", dati);
                }
            }
            using (PizzaContext db = new PizzaContext())
            {
                Pizza creoLaPizza = new Pizza();
                creoLaPizza.Title = dati.Pizze.Title;
                creoLaPizza.Ingredienti = dati.Pizze.Ingredienti;
                creoLaPizza.Image = dati.Pizze.Image;
                creoLaPizza.Image2 = dati.Pizze.Image2;
                creoLaPizza.Prezzo = dati.Pizze.Prezzo;
                creoLaPizza.CategoriaId = dati.Pizze.CategoriaId;

                db.Pizze.Add(creoLaPizza);
                db.SaveChanges();
            }
                return RedirectToAction("Index" );

        }

        [HttpGet]
        public IActionResult Aggiorna(int id)
        {
            Pizza? pizzaDaModificare = null;
            using (PizzaContext db = new PizzaContext())
            {
                      pizzaDaModificare = db.Pizze
                     .Where(pizza => pizza.id == id)
                     .FirstOrDefault();
            }
            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("Aggiorna", pizzaDaModificare);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Aggiorna(int id, Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Aggiorna", model);
            }

            Pizza? pizzaOriginale = null;

            using (PizzaContext db = new PizzaContext())
            {
                    pizzaOriginale = db.Pizze
                     .Where(pizza => pizza.id == id)
                     .FirstOrDefault();
                if (pizzaOriginale != null)
                {
                    pizzaOriginale.Title = model.Title;
                    pizzaOriginale.Ingredienti = model.Ingredienti;
                    pizzaOriginale.Image = model.Image;
                    pizzaOriginale.Image2 = model.Image2;
                    pizzaOriginale.Prezzo = model.Prezzo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
        //Metodo per eliminare la nostra pizza

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Elimina(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaDaCancellare = db.Pizze
                     .Where(pizza => pizza.id == id)
                     .FirstOrDefault();

                if (pizzaDaCancellare != null)
                {
                    db.Pizze.Remove(pizzaDaCancellare);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }  
        }
    }
}

