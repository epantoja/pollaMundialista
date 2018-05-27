using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class GrupoEquipoBl : IGrupoEquipo {
        private readonly DataContext _context;

        public GrupoEquipoBl (DataContext context) {
            _context = context;
        }

        public async Task<GrupoEquipo> ActualizarGrupoEquipo (GrupoEquipo grupoEquipo) {
            try {
                _context.GrupoEquipo.Update (grupoEquipo);
                await _context.SaveChangesAsync ();
                return grupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public Task<GrupoEquipo> BuscarGrupoEquipo (GrupoEquipo grupoEquipo) {
            throw new System.NotImplementedException ();
        }

        public async Task<GrupoEquipo> EliminarGrupoEquipo (GrupoEquipo grupoEquipo) {
            try {
                var detalleGrupoEquipo = await _context.GrupoEquipo
                    .FirstOrDefaultAsync (x => x.Id == grupoEquipo.Id);

                detalleGrupoEquipo.Estado = false;

                _context.GrupoEquipo.Update (detalleGrupoEquipo);

                await _context.SaveChangesAsync ();

                return detalleGrupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<GrupoEquipo> GuardarGrupoEquipo (GrupoEquipo grupoEquipo) {
            try {
                await _context.GrupoEquipo.AddAsync (grupoEquipo);
                await _context.SaveChangesAsync ();
                return grupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<GrupoEquipo>> ListarGrupoEquipoActivos () {
            try {
                var listaGrupoEquipo = await _context.GrupoEquipo
                    .OrderBy (x => x.Orden)
                    .Where (x => x.Estado == true)
                    .ToListAsync ();
                return listaGrupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<GrupoEquipo>> ListarGrupoEquipoTodos () {
            try {
                var listaGrupoEquipo = await _context.GrupoEquipo
                    .OrderBy (x => x.Orden)
                    .ToListAsync ();
                return listaGrupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<GrupoEquipo> ObtenerGrupoEquipo (GrupoEquipo grupoEquipo) {
            try {
                var detalleGrupoEquipo = await _context.GrupoEquipo
                    .FirstOrDefaultAsync (x => x.Id == grupoEquipo.Id);

                return detalleGrupoEquipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

    }
}