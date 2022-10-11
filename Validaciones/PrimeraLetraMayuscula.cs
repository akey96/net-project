using System.ComponentModel.DataAnnotations;

namespace WebAPIAutores.Validaciones
{
    // ValidationAttribute, Clase base para crear validaciones de atributos, usado como decoradore
    public class PrimeraLetraMayuscula: ValidationAttribute
    {
        // metodo a sobre escribir para la validacion, retorna un ValidationResult
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                // Lanza cuando la validacion es correcta
                return ValidationResult.Success;
            }

            var primeraLetra = value.ToString()[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper())
            {
                // Lanza el error para la validacion
                return new ValidationResult("La primera letra debe ser mayuscula");
            }

            return ValidationResult.Success;
        }
    }
}
