using PizzeriaCompagnone.Utils.Validazioni;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaCompagnone.Models
{
    public class Pizza
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Il campo titolo è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il titolo non può avere più di 20 caratteri")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Il campo ingredienti è obbligatorio")]
        [cinqueParole]
        public string Ingredienti { get; set; }

        [Required(ErrorMessage = "Il campo immagine è obbligatorio")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Il campo immagine è obbligatorio")]
        public string Image2 { get; set; }

        [Required(ErrorMessage = "Il campo prezzo è obbligatorio")]
        [Range(1,40, ErrorMessage = "Il valore inserito non è corretto")]
        public double Prezzo { get; set; }
        
        public int? CategoriaId { get; set; }
        public Categoria? categoria { get; set; }

        public Pizza()
        {

        }

        public Pizza(string title, string ingredienti, string image, string image2, double prezzo)
        {
            
            this.Title = title;
            this.Ingredienti = ingredienti;
            this.Image = image;
            this.Image2= image2;
            this.Prezzo = prezzo;
        }
    }
}
