using System.ComponentModel.DataAnnotations;
using Api.Helpers.CustomValidation;

namespace Api.Dto {
    public class FaseDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "La {0} debe ser entre {2} y {1} caracteres")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Color { get; set; }

        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int Orden { get; set; }
        public bool Estado { get; set; }
    }
}