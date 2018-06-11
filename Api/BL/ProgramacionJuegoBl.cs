using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class ProgramacionJuegoBl : IProgramacionJuego {

        private readonly DataContext _context;

        public ProgramacionJuegoBl (DataContext context) {
            _context = context;
        }

        public Task<ProgramacionJuego> ActualizarProgramacionJuego (ProgramacionJuego programacionJuego) {
            try {
                throw new System.NotImplementedException ();
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public Task<ProgramacionJuego> BuscarProgramacionJuego (ProgramacionJuego programacionJuego) {
            try {
                throw new System.NotImplementedException ();
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public Task<ProgramacionJuego> EliminarProgramacionJuego (ProgramacionJuego programacionJuego) {
            try {
                throw new System.NotImplementedException ();
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<ProgramacionJuego> GuardarProgramacionJuego (ProgramacionJuego programacionJuego) {
            try {
                _context.ProgramacionJuego.Add (programacionJuego);

                await _context.SaveChangesAsync ();

                return programacionJuego;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<ProgramacionJuego>> ListarProgramacionJuegoActivos () {
            try {
                var listaProgramacion = await _context.ProgramacionJuego
                    .Include (x => x.EquipoA)
                    .Include (x => x.EquipoB)
                    .Include (x => x.Fase)
                    .Where (x => x.EquipoA.Estado == true)
                    .Where (x => x.EquipoB.Estado == true)
                    .ToListAsync ();
                return listaProgramacion;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<ProgramacionJuego>> ListarProgramacionJuegoTodos () {
            try {
                var listaProgramacion = await _context.ProgramacionJuego
                    .Include (x => x.EquipoA)
                    .Include (x => x.EquipoB)
                    .Include (x => x.Fase)
                    .Where (x => x.EquipoA.Estado == true)
                    .Where (x => x.EquipoB.Estado == true)
                    .ToListAsync ();
                return listaProgramacion;
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public Task<ProgramacionJuego> ObtenerProgramacionJuego (ProgramacionJuego programacionJuego) {
            try {
                throw new System.NotImplementedException ();
            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }
    }
}