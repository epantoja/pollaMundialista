using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioRegisterDto {
        [Required (ErrorMessage = "El campo CodUsuario es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La CodUsuario debe ser entre 4 y 15 caracteres")]
        public string CodUsuario { get; set; }

        [Required (ErrorMessage = "El campo GrupoUsuarioId es requerido")]
        public int GrupoUsuarioId { get; set; }

        [Required (ErrorMessage = "El campo Nombre es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Nombre debe ser entre 4 y 150 caracteres")]
        public string Nombres { get; set; }

        [Required (ErrorMessage = "El campo Contrasena es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La Contrasena debe ser entre 4 y 15 caracteres")]
        public string Contrasena { get; set; }
    }
}