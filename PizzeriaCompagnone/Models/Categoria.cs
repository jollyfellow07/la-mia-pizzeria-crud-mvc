using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PizzeriaCompagnone.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Il campo è obbligatorio")]
        public string titolo { get; set; }
        [JsonIgnore]
        public List<Pizza> pizzas { get; set; }

        public Categoria()
        {

        }
    }
}
