using System.ComponentModel.DataAnnotations;

namespace Api.Models {
    public class ResultadosJuego {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public ProgramacionJuego ProgramacionJuego { get; set; }
        public int ProgramacionJuegoId { get; set; }

        [Required]
        public int MarcadorA { get; set; }

        [Required]
        public int MarcadoB { get; set; }

    }
}