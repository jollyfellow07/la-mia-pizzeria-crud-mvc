using System.ComponentModel.DataAnnotations;

namespace PizzeriaCompagnone.Models
{
    public class Utente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "perfavore inserisci un nome utente")]
        public string nomeUtente { get; set; }


        [Required(ErrorMessage = "perfavore inserisci una password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public Utente() { }
        public Utente(string nomeUtente, string password)
        {
            this.nomeUtente = nomeUtente;
            this.password = password;
        }
    }
}
