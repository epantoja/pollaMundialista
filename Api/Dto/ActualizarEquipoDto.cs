using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class ActualizarEquipoDto {
        [Required (ErrorMessage = "El campo Nombre es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Nombre debe ser entre 4 y 150 caracteres")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "El campo PartidosJugados es requerido")]
        public int PartidosJugados { get; set; }

        [Required (ErrorMessage = "El campo PartidosGanados es requerido")]
        public int PartidosGanados { get; set; }

        [Required (ErrorMessage = "El campo PartidosEmpatados es requerido")]
        public int PartidosEmpatados { get; set; }

        [Required (ErrorMessage = "El campo PartidosPerdidos es requerido")]
        public int PartidosPerdidos { get; set; }

        [Required (ErrorMessage = "El campo GolesAFavor es requerido")]
        public int GolesAFavor { get; set; }

        [Required (ErrorMessage = "El campo GolesEnContra es requerido")]
        public int GolesEnContra { get; set; }

        [Required (ErrorMessage = "El campo DiferenciaGoles es requerido")]
        public int DiferenciaGoles { get; set; }

        [Required (ErrorMessage = "El campo Puntos es requerido")]
        public int Puntos { get; set; }

        [Required (ErrorMessage = "El campo Grupo es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Grupo debe ser entre 4 y 150 caracteres")]
        public string Grupo { get; set; }

    }
}