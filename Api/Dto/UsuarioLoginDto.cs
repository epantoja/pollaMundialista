using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioLoginDto {

        [Required (ErrorMessage = "El campo CodUsuario es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La CodUsuario debe ser entre 4 y 15 caracteres")]
        public string CodUsuario { get; set; }

        [Required (ErrorMessage = "El campo GrupoUsuarioId es requerido")]
        public int GrupoUsuarioId { get; set; }

        [Required (ErrorMessage = "El campo Contrasena es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La Contrasena debe ser entre 4 y 15 caracteres")]
        public string Contrasena { get; set; }
    }
}