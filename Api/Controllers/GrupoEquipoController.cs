using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dto;
using Api.Interface;
using Api.Models;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {

    [Authorize]
    [Route ("api/[controller]")]
    public class GrupoEquipoController : Controller {
        private readonly IGrupoEquipo _grupoEquipo;
        private readonly IMapper _mapper;

        public GrupoEquipoController (IMapper mapper, IGrupoEquipo grupoEquipo) {
            _mapper = mapper;
            _grupoEquipo = grupoEquipo;
        }

        [HttpGet ("ListarTodos")]
        public async Task<IActionResult> ListarTodos () {

            var grupoEquipoLista = await _grupoEquipo.ListarGrupoEquipoTodos ();

            var grupoEquipoReturn = _mapper.Map<List<GrupoEquipoListaDto>> (grupoEquipoLista);

            return Ok (grupoEquipoReturn);
        }

        [HttpGet ("Listar")]
        public async Task<IActionResult> ListarActivos () {

            var grupoEquipoLista = await _grupoEquipo.ListarGrupoEquipoActivos ();

            var grupoEquipoReturn = _mapper.Map<List<GrupoEquipoListaDto>> (grupoEquipoLista);

            return Ok (grupoEquipoReturn);
        }

        [HttpGet ("Obtener/{Id}")]
        public async Task<IActionResult> ObtenerGrupoEquipo (int Id) {

            var buscarGrupoEquipo = new GrupoEquipo {
                Id = Id
            };

            var grupoEquipo = await _grupoEquipo.ObtenerGrupoEquipo (buscarGrupoEquipo);

            var grupoEquipoReturn = _mapper.Map<GrupoEquipoListaDto> (grupoEquipo);

            return Ok (grupoEquipoReturn);
        }

        [HttpPost ("Guardar")]
        public async Task<IActionResult> GuardarGrupoEquipo ([FromBody] GrupoEquipoDto grupoEquipoDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var guardarGrupoEquipo = new GrupoEquipo {
                Nombre = grupoEquipoDto.Nombre,
                Color = grupoEquipoDto.Color,
                Orden = grupoEquipoDto.Orden
            };

            var grupoEquipo = await _grupoEquipo.GuardarGrupoEquipo (guardarGrupoEquipo);

            var grupoEquipoReturn = _mapper.Map<GrupoEquipoListaDto> (grupoEquipo);

            return Ok (grupoEquipoReturn);
        }

        [HttpGet ("Eliminar/{Id}")]
        public async Task<IActionResult> EliminarGrupoEquipo (int Id) {

            var buscarGrupoEquipo = new GrupoEquipo {
                Id = Id
            };

            var grupoEquipo = await _grupoEquipo.EliminarGrupoEquipo (buscarGrupoEquipo);

            var listaGrupoEquipoReturn = _mapper.Map<List<GrupoEquipoListaDto>> (await _grupoEquipo.ListarGrupoEquipoTodos ());

            return Ok (listaGrupoEquipoReturn);
        }

        [HttpPut ("Actualizar/{Id}")]
        public async Task<IActionResult> ActualizarGrupoEquipo (int Id, [FromBody] GrupoEquipoDto grupoEquipoDto) {

            var buscarGrupoEquipo = new GrupoEquipo {
                Id = Id,
                Nombre = grupoEquipoDto.Nombre,
                Color = grupoEquipoDto.Color,
                Orden = grupoEquipoDto.Orden,
                Estado = grupoEquipoDto.Estado
            };

            var grupoEquipo = await _grupoEquipo.ActualizarGrupoEquipo (buscarGrupoEquipo);

            var listaGrupoEquipoReturn = _mapper.Map<GrupoEquipoListaDto> (grupoEquipo);

            return Ok (listaGrupoEquipoReturn);
        }
    }
}