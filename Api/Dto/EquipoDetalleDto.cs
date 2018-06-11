using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Api.Dto {
    public class EquipoDetalleDto {
        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Nombre { get; set; }
        public string BanderaUrl { get; set; }
        public string PublicId { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int PartidosJugados { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int PartidosGanados { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int PartidosEmpatados { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int PartidosPerdidos { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int GolesAFavor { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int GolesEnContra { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int DiferenciaGoles { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public int Puntos { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public IFormFile File { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El {0} debe ser entre {2} y {1} caracteres")]
        public string Grupo { get; set; }
    }
}