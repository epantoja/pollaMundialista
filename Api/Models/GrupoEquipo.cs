using System.ComponentModel.DataAnnotations;

namespace Api.Models {
    public class GrupoEquipo {
        public GrupoEquipo () {
            Estado = true;
        }
        public int Id { get; set; }

        [Required]
        [StringLength (150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength (150)]
        public string Color { get; set; }
        public bool Estado { get; set; }
    }
}