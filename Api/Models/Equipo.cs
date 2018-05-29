using System.ComponentModel.DataAnnotations;

namespace Api.Models {
    public class Equipo {
        public Equipo () {
            Estado = true;
            PartidosJugados = 0;
            PartidosGanados = 0;
            PartidosEmpatados = 0;
            PartidosPerdidos = 0;
            GolesAFavor = 0;
            GolesEnContra = 0;
            Puntos = 0;
        }
        public int Id { get; set; }

        [Required]
        [StringLength (150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength (150)]
        public string BanderaUrl { get; set; }
        public string PublicId { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public int DiferenciaGoles { get; set; }
        public int Puntos { get; set; }

        [Required]
        [StringLength (150)]
        public string Grupo { get; set; }
        public bool Estado { get; set; }
    }
}