using System.ComponentModel.DataAnnotations;

namespace Api.Dto {
    public class GrupoEquipoDto {
        [Required (ErrorMessage = "El campo Nombre es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "La Nombre debe ser entre 4 y 150 caracteres")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "El campo Color es requerido")]
        [StringLength (150, MinimumLength = 4, ErrorMessage = "El Color debe ser entre 4 y 150 caracteres")]
        public string Color { get; set; }
        public int Orden { get; set; }
        public bool Estado { get; set; }
    }
}