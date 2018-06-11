using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo  {0} es requerido")]
        [StringLength (15, MinimumLength = 4, ErrorMessage = "La  {0} debe ser entre {2} y {2} caracteres")]
        public string CodUsuario { get; set; }
    }
}