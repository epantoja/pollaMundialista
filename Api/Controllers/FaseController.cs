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
    public class FaseController : Controller {
        private readonly IFase _fase;
        private readonly IMapper _mapper;

        public FaseController (IMapper mapper, IFase fase) {
            _mapper = mapper;
            _fase = fase;
        }

        [HttpGet ("ListarTodos")]
        public async Task<IActionResult> ListarTodos () {

            var faseLista = await _fase.ListarFaseTodos ();

            var faseReturn = _mapper.Map<List<FaseListaDto>> (faseLista);

            return Ok (faseReturn);
        }

        [HttpGet ("Listar")]
        public async Task<IActionResult> ListarActivos () {

            var faseLista = await _fase.ListarFaseActivos ();

            var faseReturn = _mapper.Map<List<FaseListaDto>> (faseLista);

            return Ok (faseReturn);
        }

        [HttpGet ("Obtener/{Id}")]
        public async Task<IActionResult> ObtenerFase (int Id) {

            var buscarFase = new Fase {
                Id = Id
            };

            var fase = await _fase.ObtenerFase (buscarFase);

            var faseReturn = _mapper.Map<FaseListaDto> (fase);

            return Ok (faseReturn);
        }

        [HttpPost ("Guardar")]
        public async Task<IActionResult> GuardarFase ([FromBody] FaseDto faseDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var guardarFase = new Fase {
                Nombre = faseDto.Nombre,
                Color = faseDto.Color,
                Orden = faseDto.Orden
            };

            var fase = await _fase.GuardarFase (guardarFase);

            var faseReturn = _mapper.Map<FaseListaDto> (fase);

            return Ok (faseReturn);
        }

        [HttpGet ("Eliminar/{Id}")]
        public async Task<IActionResult> EliminarFase (int Id) {

            var buscarFase = new Fase {
                Id = Id
            };

            var fase = await _fase.EliminarFase (buscarFase);

            var listaFaseReturn = _mapper.Map<List<FaseListaDto>> (await _fase.ListarFaseTodos ());

            return Ok (listaFaseReturn);
        }

        [HttpPut ("Actualizar/{Id}")]
        public async Task<IActionResult> ActualizarFase (int Id, [FromBody] FaseDto faseDto) {

            var buscarFase = new Fase {
                Id = Id,
                Nombre = faseDto.Nombre,
                Color = faseDto.Color,
                Orden = faseDto.Orden,
                Estado = faseDto.Estado
            };

            var fase = await _fase.ActualizarFase (buscarFase);

            var listaFaseReturn = _mapper.Map<FaseListaDto> (fase);

            return Ok (listaFaseReturn);
        }
    }
}