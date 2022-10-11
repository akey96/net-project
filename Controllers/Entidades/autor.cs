using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAutores.Controllers.Entidades;
using WebAPIAutores.Validaciones;

namespace WebAPIAutores.Entidades {

    // IValidatableObject, Interfaz que sirve para crear validaciones a nivel de Modelo
    public class Autor : IValidatableObject{
        public int Id {get; set;}

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 120, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
        public string Nombre { get; set; }

        // NotMapped, significa que no se creara esa columna en la tabla, es como un campo temporal.
        [Range(18, 120)]
        [NotMapped]
        public int Edad { get; set; }

        [CreditCard]
        [NotMapped]
        public string TarjetaDeCredito { get; set; }

        [Url]
        [NotMapped]
        public string URL { get; set; }

        // lista de objetos(Libros) que guardan relacion con Autor, Libros que pertenecen a este Autor
        public List<Libro> Libros { get; set; }


        // Validacion a nivel de modelo, se aplica una vez haya pasado las validaciones a nivel de campos
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula desde el Modelo",
                        new string[] { nameof(Nombre) });
                }
            }
        }
    } 

}