using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioActualizarDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Nombre debe ser entre {2} y {1} caracteres")]
        public string Nombres { get; set; }
    }
}