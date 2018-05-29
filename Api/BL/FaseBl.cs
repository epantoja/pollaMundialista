using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.BL {
    public class FaseBl : IFase {
        private readonly DataContext _context;

        public FaseBl (DataContext context) {
            _context = context;
        }

        public async Task<Fase> ActualizarFase (Fase fase) {
            try {
                _context.Fase.Update (fase);
                await _context.SaveChangesAsync ();
                return fase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public Task<Fase> BuscarFase (Fase fase) {
            throw new System.NotImplementedException ();
        }

        public async Task<Fase> EliminarFase (Fase fase) {
            try {
                var detalleFase = await _context.Fase
                    .FirstOrDefaultAsync (x => x.Id == fase.Id);

                detalleFase.Estado = false;

                _context.Fase.Update (detalleFase);

                await _context.SaveChangesAsync ();

                return detalleFase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Fase> GuardarFase (Fase fase) {
            try {
                await _context.Fase.AddAsync (fase);
                await _context.SaveChangesAsync ();
                return fase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<Fase>> ListarFaseActivos () {
            try {
                var listaFase = await _context.Fase
                    .OrderBy (x => x.Orden)
                    .Where (x => x.Estado == true)
                    .ToListAsync ();
                return listaFase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<List<Fase>> ListarFaseTodos () {
            try {
                var listaFase = await _context.Fase
                    .OrderBy (x => x.Orden)
                    .ToListAsync ();
                return listaFase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

        public async Task<Fase> ObtenerFase (Fase fase) {
            try {
                var detalleFase = await _context.Fase
                    .FirstOrDefaultAsync (x => x.Id == fase.Id);

                return detalleFase;

            } catch (Exception) {
                throw new Exception ("Ocurrio un error interno, por favor comunicare con el administrador");
            }
        }

    }
}