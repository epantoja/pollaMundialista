using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioDto {
        [Required (ErrorMessage = "El campo Id es requerido")]
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo CodUsuario es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La CodUsuario debe ser entre 4 y 15 caracteres")]
        public string CodUsuario { get; set; }
    }
}