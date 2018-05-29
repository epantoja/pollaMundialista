using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interface {
    public interface IFase {
        Task<List<Fase>> ListarFaseActivos ();
        Task<List<Fase>> ListarFaseTodos ();
        Task<Fase> ObtenerFase (Fase fase);
        Task<Fase> BuscarFase (Fase fase);
        Task<Fase> GuardarFase (Fase fase);
        Task<Fase> ActualizarFase (Fase fase);
        Task<Fase> EliminarFase (Fase fase);
    }
}