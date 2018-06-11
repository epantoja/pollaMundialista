using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Dto;
using Api.Interface;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {

    [Authorize]
    [Route ("api/[controller]")]
    public class ProgramacionJuegoController : Controller {
        private readonly IMapper _mapper;
        private readonly IProgramacionJuego _programacionJuego;
        public ProgramacionJuegoController (IMapper mapper, IProgramacionJuego programacionJuego) {
            _mapper = mapper;
            _programacionJuego = programacionJuego;
        }

        [HttpGet ("ListarTodos")]
        public async Task<IActionResult> ListarTodos () {

            var programacionJuegoLista = await _programacionJuego.ListarProgramacionJuegoTodos ();

            var faseReturn = _mapper.Map<List<ProgramacionJuegoListaDto>> (programacionJuegoLista);

            return Ok (faseReturn);
        }

        [HttpPost ("Guardar")]
        public async Task<IActionResult> GuardarProgramacionJuego ([FromBody] ProgramacionJuegoRegistroDto programacionJuegoRegistroDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var programacion = _mapper.Map<ProgramacionJuego> (programacionJuegoRegistroDto);

            var programacionJuegoLista = await _programacionJuego.GuardarProgramacionJuego (programacion);

            var faseReturn = _mapper.Map<ProgramacionJuegoListaDto> (programacionJuegoLista);

            return Ok (faseReturn);
        }
    }
}