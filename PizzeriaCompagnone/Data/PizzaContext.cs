using Microsoft.EntityFrameworkCore;
using PizzeriaCompagnone.Models;

namespace PizzeriaCompagnone.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=DbPizzeria; Integrated Security=True");
        }
    }
}