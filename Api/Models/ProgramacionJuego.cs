using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models {
    public class ProgramacionJuego {
        public ProgramacionJuego () {
            MarcadorA = 0;
            MarcadorB = 0;
        }

        public int Id { get; set; }

        [Required]
        public DateTime FechaJuego { get; set; }
        public Equipo EquipoA { get; set; }

        [ForeignKey ("Equipo")]
        public int EquipoAId { get; set; }

        [Required]
        public int MarcadorA { get; set; }
        public Equipo EquipoB { get; set; }

        [ForeignKey ("Equipo")]
        public int EquipoBId { get; set; }

        [Required]
        public int MarcadorB { get; set; }

        public Fase Fase { get; set; }
        public int FaseId { get; set; }

        [Required]
        public int Orden { get; set; }

    }
}