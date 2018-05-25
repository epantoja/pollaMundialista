using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class UsuarioActualizarDto {
        [Required (ErrorMessage = "El campo Nombre es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Nombre debe ser entre 4 y 150 caracteres")]
        public string Nombres { get; set; }
    }
}