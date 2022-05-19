using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzeriaCompagnone.Data;
using PizzeriaCompagnone.Models;

namespace PizzeriaCompagnone.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(String? cerca)
        {
            List<Pizza> pizzaLista = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {

                // LOGICA PER RICERCARE I POST CHE CONTENGONO NEL TIUOLO O NELLA DESCRIZIONE LA STRINGA DI RICERCA
                if (cerca != null && cerca != "")
                {
                    pizzaLista = db.Pizze.Where(pizza => pizza.Title.Contains(cerca) || pizza.Ingredienti.Contains(cerca)).ToList<Pizza>();
                }
                else
                {
                    pizzaLista = db.Pizze.ToList<Pizza>();
                }
            }
            return Ok(pizzaLista);
        }

    }
}
