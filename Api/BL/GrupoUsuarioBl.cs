using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class GrupoUsuarioBl : IGrupoUsuario {
        private readonly DataContext _context;

        public GrupoUsuarioBl (DataContext context) {
            _context = context;
        }

        public async Task<GrupoUsuario> GuardarGrupoUsuario (GrupoUsuario grupoUsuario) {
            throw new System.NotImplementedException ();
        }

        public async Task<GrupoUsuario> ActualizarGrupoUsuario (GrupoUsuario grupoUsuario) {
            throw new System.NotImplementedException ();
        }

        public async Task<List<GrupoUsuario>> ListarGrupoUsuarioActivos () {
            try {
                var listaGrupoUsuario = await _context.GrupoUsuario
                    .Where (x => x.Estado == true).ToListAsync ();
                return listaGrupoUsuario;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<GrupoUsuario>> ListarGrupoUsuarioTodos () {
            try {
                var listaGrupoUsuario = await _context.GrupoUsuario.ToListAsync ();
                return listaGrupoUsuario;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<GrupoUsuario> ObtenerGrupoUsuario (GrupoUsuario grupoUsuario) {
            try {
                var DetalleGrupoUsuario = await _context.GrupoUsuario
                    .FirstOrDefaultAsync (x => x.Id == grupoUsuario.Id);
                return DetalleGrupoUsuario;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }
    }
}