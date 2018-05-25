using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface {
    public interface IGrupoUsuario {
        Task<List<GrupoUsuario>> ListarGrupoUsuarioActivos ();
        Task<List<GrupoUsuario>> ListarGrupoUsuarioTodos ();
        Task<GrupoUsuario> ObtenerGrupoUsuario (GrupoUsuario grupoUsuario);
        Task<GrupoUsuario> GuardarGrupoUsuario (GrupoUsuario grupoUsuario);
        Task<GrupoUsuario> ActualizarGrupoUsuario (GrupoUsuario grupoUsuario);
    }
}