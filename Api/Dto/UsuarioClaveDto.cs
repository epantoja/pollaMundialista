using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioClaveDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La {0} debe ser entre {2} y {1} caracteres")]
        public string Contrasena { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La {0} debe ser entre {2} y {1} caracteres")]
        public string ContrasenaNueva { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "{0} debe ser entre {2} y {1} caracteres")]
        public string ConfirmarContrasena { get; set; }
    }
}