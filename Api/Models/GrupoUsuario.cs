using System.ComponentModel.DataAnnotations;

namespace Api.Models {
    public class GrupoUsuario {
        public GrupoUsuario () {
            Estado = true;
        }
        public int Id { get; set; }

        [Required]
        [StringLength (150)]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}