using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class UsuarioBl : IUsuario {

        private readonly DataContext _context;

        public UsuarioBl (DataContext context) {
            _context = context;
        }

        public async Task<bool> ActualizarClaveUsuario (int id, string nuevaContrasena) {
            try {

                var usuario = await _context.Usuario.FirstOrDefaultAsync (x => x.Id == id);

                byte[] contrasenaHash, contrasenaSalt;
                CreatePasswordHash (nuevaContrasena, out contrasenaHash, out contrasenaSalt);
                usuario.ContrasenaHash = contrasenaHash;
                usuario.ContrasenaSalt = contrasenaSalt;

                var result = await _context.SaveChangesAsync () > 0;
                return result;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<bool> ActualizarUsuario (Usuario usuario) {
            try {
                _context.Usuario.Update (usuario);
                var result = await _context.SaveChangesAsync () > 0;
                return result;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Usuario> GuardarUsuario (string contrasena, Usuario usuario, UsuarioGrupoUsuario usuarioGrupoUsuario) {
            try {
                byte[] contrasenaHash, contrasenaSalt;
                CreatePasswordHash (contrasena, out contrasenaHash, out contrasenaSalt);
                usuario.ContrasenaHash = contrasenaHash;
                usuario.ContrasenaSalt = contrasenaSalt;

                await _context.Usuario.AddAsync (usuario);

                usuarioGrupoUsuario.UsuarioId = usuario.Id;

                await _context.UsuarioGrupoUsuario.AddAsync (usuarioGrupoUsuario);

                await _context.SaveChangesAsync ();

                return usuario;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Usuario> VerificarUsuario (Usuario usuario) {
            try {
                var user = await _context.Usuario
                    .FirstOrDefaultAsync (x => x.CodUsuario == usuario.CodUsuario);

                if (user == null)
                    return null;

                return user;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Usuario> LoginUsuario (string contrasena, Usuario usuario, UsuarioGrupoUsuario usuarioGrupoUsuario) {

            try {
                var resultUsuarioGrupoUsuario = await _context.UsuarioGrupoUsuario
                    .Include (x => x.Usuario)
                    .FirstOrDefaultAsync (x => x.Usuario.CodUsuario == usuario.CodUsuario &&
                        x.GrupoUsuarioId == usuarioGrupoUsuario.GrupoUsuarioId);

                if (resultUsuarioGrupoUsuario == null)
                    return null;

                var user = resultUsuarioGrupoUsuario.Usuario;
                if (user == null)
                    return null;

                if (!VerifyPasswordHash (contrasena, user.ContrasenaHash, user.ContrasenaSalt))
                    return null;

                return user;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }

        }

        public async Task<List<Usuario>> ListarUsuarioActivos () {
            try {
                var listaUsuario = await _context.Usuario
                    .Where (x => x.Estado == true).ToListAsync ();
                return listaUsuario;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<Usuario>> ListarUsuarioTodos () {
            try {
                var listaUsuario = await _context.Usuario.ToListAsync ();
                return listaUsuario;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Usuario> ObtenerUsuario (Usuario usuario) {
            try {

                var listaGrupo = await (from gu in _context.UsuarioGrupoUsuario join g in _context.GrupoUsuario on gu.GrupoUsuarioId equals g.Id where gu.UsuarioId == usuario.Id select new GrupoUsuario {
                    Id = g.Id,
                        Nombre = g.Nombre,
                        Estado = g.Estado
                }).ToListAsync ();

                if (listaGrupo.Count () == 0)
                    return null;

                var resultUsuario = await (from u in _context.Usuario where u.Id == usuario.Id select new Usuario {
                    Id = u.Id,
                        Nombres = u.Nombres,
                        CodUsuario = u.CodUsuario,
                        Estado = u.Estado,
                        GrupoUsuario = listaGrupo,
                        ContrasenaHash = u.ContrasenaHash,
                        ContrasenaSalt = u.ContrasenaSalt
                }).FirstAsync ();

                return resultUsuario;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        private bool VerifyPasswordHash (string contrasena, byte[] contrasenaHash, byte[] contrasenaSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 (contrasenaSalt)) {
                var computeHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (contrasena));
                for (int i = 0; i < computeHash.Length; i++) {
                    if (computeHash[i] != contrasenaHash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePasswordHash (string contrasena, out byte[] contrasenaHash, out byte[] contrasenaSalt) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512 ()) {
                contrasenaSalt = hmac.Key;
                contrasenaHash = hmac.ComputeHash (System.Text.Encoding.UTF8.GetBytes (contrasena));
            }
        }
    }
}