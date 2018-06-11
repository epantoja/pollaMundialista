using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dto;
using Api.Helpers;
using Api.Interface;
using Api.Models;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers {
    [Authorize]
    [Route ("api/[controller]")]
    public class EquipoController : Controller {
        private readonly IEquipo _equipo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinariConfig;
        private readonly Cloudinary _cloudinary;

        public EquipoController (IEquipo equipo,
            IMapper mapper,
            IOptions<CloudinarySettings> cloudinariConfig) {
            _equipo = equipo;
            _mapper = mapper;
            _cloudinariConfig = cloudinariConfig;

            Account Acc = new Account (
                _cloudinariConfig.Value.CloudName,
                _cloudinariConfig.Value.ApiKey,
                _cloudinariConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary (Acc);
        }

        [HttpPost ("Guardar")]
        public async Task<IActionResult> GuardarEquipo (EquipoRegistroDto equipoREgistroDto) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var equipoBuscar = new Equipo {
                Nombre = equipoREgistroDto.Nombre
            };

            if (await _equipo.BuscarEquipo (equipoBuscar) != null)
                return BadRequest ("Ya existe un equipo con este nombre");

            var archivo = equipoREgistroDto.File;

            var uploadResult = new ImageUploadResult ();

            if (archivo.Length > 0) {
                using (var stream = archivo.OpenReadStream ()) {
                    var uploadParamns = new ImageUploadParams () {
                    File = new FileDescription (archivo.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload (uploadParamns);
                }
            }

            equipoREgistroDto.BanderaUrl = uploadResult.Uri.ToString ();
            equipoREgistroDto.PublicId = uploadResult.PublicId;

            var equipoGuardar = _mapper.Map<Equipo> (equipoREgistroDto);

            var equipoResult = await _equipo.GuardarEquipo (equipoGuardar);

            return Ok (equipoResult);
        }

        [HttpGet ("Listar")]
        public async Task<IActionResult> ListarEquipo () {
            var listaEquipo = await _equipo.ListarEquipoActivos ();

            var resultListaEquipo = _mapper.Map<ICollection<Equipo>> (listaEquipo);

            return Ok (resultListaEquipo);
        }

        [HttpGet ("Eliminar/{Id}")]
        public async Task<IActionResult> EliminarEquipo (int Id) {

            if (Id == 0)
                return BadRequest ("No hay equipo para eliminar");

            var equipoBuscar = new Equipo {
                Id = Id
            };

            if (await _equipo.ObtenerEquipo (equipoBuscar) == null)
                return BadRequest ("El id del equipo no existe");

            var listaEquipo = await _equipo.EliminarEquipo (equipoBuscar);

            return Ok ("Eliminado Correctamente");
        }

        [HttpPut ("Actualizar/{Id}")]
        public async Task<IActionResult> ActualizarEquipo (int Id, [FromBody] ActualizarEquipoDto actualizarEquipoDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            if (Id == 0)
                return BadRequest ("No hay equipo para actualizar");

            var equipoBuscar = new Equipo {
                Id = Id
            };

            var obtenerEquipo = await _equipo.ObtenerEquipo (equipoBuscar);

            if (obtenerEquipo == null)
                return BadRequest ("El id del equipo no existe");

            obtenerEquipo.PartidosGanados = actualizarEquipoDto.PartidosGanados;
            obtenerEquipo.PartidosJugados = actualizarEquipoDto.PartidosJugados;
            obtenerEquipo.PartidosPerdidos = actualizarEquipoDto.PartidosPerdidos;
            obtenerEquipo.GolesAFavor = actualizarEquipoDto.GolesAFavor;
            obtenerEquipo.GolesEnContra = actualizarEquipoDto.GolesEnContra;
            obtenerEquipo.DiferenciaGoles = actualizarEquipoDto.DiferenciaGoles;
            obtenerEquipo.Puntos = actualizarEquipoDto.Puntos;
            obtenerEquipo.Grupo = actualizarEquipoDto.Grupo;

            var resultEquipo = await _equipo.ActualizarEquipo (obtenerEquipo);

            var mapResultEquipo = _mapper.Map<EquipoDetalleDto> (resultEquipo);

            return Ok (mapResultEquipo);
        }

        [HttpGet ("Obtener/{Id}")]
        public async Task<IActionResult> ObtenerEquipo (int Id) {

            if (Id == 0)
                return BadRequest ("No hay equipo para buscar");

            var equipoBuscar = new Equipo {
                Id = Id
            };

            if (await _equipo.ObtenerEquipo (equipoBuscar) == null)
                return BadRequest ("El id del equipo no existe");

            var detallleEquipo = await _equipo.ObtenerEquipo (equipoBuscar);

            var resulEquipoDetalle = _mapper.Map<EquipoDetalleDto> (detallleEquipo);

            return Ok (resulEquipoDetalle);
        }
    }
}