using System.ComponentModel.DataAnnotations;

namespace PizzeriaCompagnone.Utils.Validazioni
{
    public class cinqueParole : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
           
            string fieldValue = (string)value;
            if (fieldValue != null)
            {
                fieldValue = fieldValue.Trim();
                int count = fieldValue.Split(' ').Length - 1;
                if (count >= 4)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("il campo deve avere almeno 5 parole");
        }

    }
}