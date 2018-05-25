using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models {
    public class Usuario {
        public Usuario () {
            Estado = true;
            GrupoUsuario = new Collection<GrupoUsuario> ();
        }

        public int Id { get; set; }

        [Required]
        [StringLength (150)]
        public string CodUsuario { get; set; }

        [Required]
        [StringLength (240)]
        public string Nombres { get; set; }

        [Required]
        public byte[] ContrasenaHash { get; set; }

        [Required]
        public byte[] ContrasenaSalt { get; set; }
        public bool Estado { get; set; }

        [NotMapped]
        public ICollection<GrupoUsuario> GrupoUsuario { get; set; }
    }
}