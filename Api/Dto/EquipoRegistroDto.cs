using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Api.Dto {
    public class EquipoRegistroDto {
        [Required (ErrorMessage = "El campo Nombre es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Nombre debe ser entre 4 y 150 caracteres")]
        public string Nombre { get; set; }
        public string BanderaUrl { get; set; }
        public string PublicId { get; set; }
        public IFormFile File { get; set; }

        [Required (ErrorMessage = "El campo Grupo es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Grupo debe ser entre 4 y 150 caracteres")]
        public string Grupo { get; set; }
    }
}