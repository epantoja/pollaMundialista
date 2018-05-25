using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioClaveDto {
        [Required (ErrorMessage = "El campo Contrasena es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La Contrasena debe ser entre 4 y 15 caracteres")]
        public string Contrasena { get; set; }

        [Required (ErrorMessage = "El campo Contrasena Nueva es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La Contrasena Nueva debe ser entre 4 y 15 caracteres")]
        public string ContrasenaNueva { get; set; }

        [Required (ErrorMessage = "El campo Confirmar Contrasena es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "Confirmar Contrasena debe ser entre 4 y 15 caracteres")]
        public string ConfirmarContrasena { get; set; }
    }
}