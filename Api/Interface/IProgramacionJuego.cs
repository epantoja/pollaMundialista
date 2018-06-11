using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface {
    public interface IProgramacionJuego {
        Task<List<ProgramacionJuego>> ListarProgramacionJuegoActivos ();
        Task<List<ProgramacionJuego>> ListarProgramacionJuegoTodos ();
        Task<ProgramacionJuego> ObtenerProgramacionJuego (ProgramacionJuego programacionJuego);
        Task<ProgramacionJuego> BuscarProgramacionJuego (ProgramacionJuego programacionJuego);
        Task<ProgramacionJuego> GuardarProgramacionJuego (ProgramacionJuego programacionJuego);
        Task<ProgramacionJuego> ActualizarProgramacionJuego (ProgramacionJuego programacionJuego);
        Task<ProgramacionJuego> EliminarProgramacionJuego (ProgramacionJuego programacionJuego);
    }
}