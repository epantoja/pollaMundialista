using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface {
    public interface IGrupoEquipo {
        Task<List<GrupoEquipo>> ListarGrupoEquipoActivos ();
        Task<List<GrupoEquipo>> ListarGrupoEquipoTodos ();
        Task<GrupoEquipo> ObtenerGrupoEquipo (GrupoEquipo grupoEquipo);
        Task<GrupoEquipo> BuscarGrupoEquipo (GrupoEquipo grupoEquipo);
        Task<GrupoEquipo> GuardarGrupoEquipo (GrupoEquipo grupoEquipo);
        Task<GrupoEquipo> ActualizarGrupoEquipo (GrupoEquipo grupoEquipo);
        Task<GrupoEquipo> EliminarGrupoEquipo (GrupoEquipo grupoEquipo);
    }
}