using System.ComponentModel.DataAnnotations;

namespace Api.Models {
    public class UsuarioGrupoUsuario {

        public UsuarioGrupoUsuario () {
            Estado = true;
        }

        public int Id { get; set; }
        public Usuario Usuario { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public GrupoUsuario GrupoUsuario { get; set; }

        [Required]
        public int GrupoUsuarioId { get; set; }
        public bool Estado { get; set; }
    }
}