using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface {
    public interface IUsuario {
        Task<List<Usuario>> ListarUsuarioActivos ();
        Task<List<Usuario>> ListarUsuarioTodos ();
        Task<Usuario> ObtenerUsuario (Usuario usuario);
        Task<Usuario> GuardarUsuario (string contrasena, Usuario usuario, UsuarioGrupoUsuario usuarioGrupoUsuario);
        Task<bool> ActualizarUsuario (Usuario usuario);
        Task<bool> ActualizarClaveUsuario (int id, string nuevaContrasena);
        Task<Usuario> LoginUsuario (string contrasena, Usuario usuario, UsuarioGrupoUsuario usuarioGrupoUsuario);
        Task<Usuario> VerificarUsuario (Usuario usuario);
    }
}