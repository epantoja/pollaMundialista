using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Api.Dto {
    public class EquipoRegistroDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Nombre { get; set; }
        public string BanderaUrl { get; set; }
        public string PublicId { get; set; }
        public IFormFile File { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Grupo { get; set; }
    }
}