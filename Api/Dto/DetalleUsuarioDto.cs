using System.Collections.Generic;

namespace Api.Dto {
    public class DetalleUsuarioDto {

        public DetalleUsuarioDto () {
            GrupoUsuario = new List<GrupoUsuarioListaDto> ();
        }

        public int Id { get; set; }
        public string CodUsuario { get; set; }
        public string Nombres { get; set; }
        public bool Estado { get; set; }
        public GrupoUsuarioListaDto GrupoActual { get; set; }
        public List<GrupoUsuarioListaDto> GrupoUsuario { get; set; }
    }
}