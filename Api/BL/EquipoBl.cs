using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class EquipoBl : IEquipo {

        private readonly DataContext _context;

        public EquipoBl (DataContext context) {
            _context = context;
        }

        public async Task<Equipo> EliminarEquipo (Equipo equipo) {
            try {
                var equipoBuscar = await _context.Equipo.FirstOrDefaultAsync (x => x.Id == equipo.Id);

                equipoBuscar.Estado = false;

                _context.Equipo.Update (equipoBuscar);

                await _context.SaveChangesAsync ();

                return equipoBuscar;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Equipo> ActualizarEquipo (Equipo equipo) {
            try {
                 _context.Equipo.Update (equipo);

                await _context.SaveChangesAsync ();

                return equipo;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Equipo> GuardarEquipo (Equipo equipo) {
            try {
                await _context.Equipo.AddAsync (equipo);
                await _context.SaveChangesAsync ();
                return equipo;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<Equipo>> ListarEquipoActivos () {
            try {
                var listaEquipo = await _context.Equipo
                    .Where (x => x.Estado == true).ToListAsync ();
                return listaEquipo;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<Equipo>> ListarEquipoTodos () {
            try {
                var listaEquipo = await _context.Equipo.ToListAsync ();
                return listaEquipo;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Equipo> ObtenerEquipo (Equipo equipo) {
            try {
                var equipoBuscar = await _context.Equipo.FirstOrDefaultAsync (x => x.Id == equipo.Id);
                return equipoBuscar;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Equipo> BuscarEquipo (Equipo equipo) {
            try {
                var equipoBuscar = await _context.Equipo
                    .FirstOrDefaultAsync (x => x.Nombre.ToLower ().Contains (equipo.Nombre.ToLower ()));
                return equipoBuscar;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }
    }
}