using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface
{
    public interface IEquipo
    {
        Task<List<Equipo>> ListarEquipoActivos ();
        Task<List<Equipo>> ListarEquipoTodos ();
        Task<Equipo> ObtenerEquipo (Equipo equipo);
        Task<Equipo> BuscarEquipo (Equipo equipo);
        Task<Equipo> GuardarEquipo (Equipo equipo);
        Task<Equipo> ActualizarEquipo (Equipo equipo);
        Task<Equipo> EliminarEquipo (Equipo equipo);
    }
}