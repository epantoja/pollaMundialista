using System;
using System.ComponentModel.DataAnnotations;
using Api.Helpers.CustomValidation;

namespace Api.Dto {
    public class ProgramacionJuegoRegistroDto {

        [Required (ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaJuego { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int EquipoAId { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int EquipoBId { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int FaseId { get; set; }

        [Required (ErrorMessage = "El campo {0} es requerido")]
        [MayorCero (ErrorMessage = "El {0} debe ser mayor a cero")]
        public int Orden { get; set; }
    }

}