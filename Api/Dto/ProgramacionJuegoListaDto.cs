using System;
using Api.Models;

namespace Api.Dto {
    public class ProgramacionJuegoListaDto {
        public int Id { get; set; }
        public DateTime FechaJuego { get; set; }
        public EquipoListaDto EquipoA { get; set; }
        public int MarcadorA { get; set; }
        public EquipoListaDto EquipoB { get; set; }
        public int MarcadorB { get; set; }
        public FaseListaDto Fase { get; set; }
        public int Orden { get; set; }
    }
}