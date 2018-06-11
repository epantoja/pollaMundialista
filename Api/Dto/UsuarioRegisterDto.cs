using System.ComponentModel.DataAnnotations;
using Api.Helpers.CustomValidation;

namespace Api.Dto {
    public class UsuarioRegisterDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La {0} debe ser entre {2} y {1} caracteres")]
        public string CodUsuario { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int GrupoUsuarioId { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Nombres { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La {0} debe ser entre {2} y {1} caracteres")]
        public string Contrasena { get; set; }
    }
}