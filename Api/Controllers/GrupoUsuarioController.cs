using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dto;
using Api.Interface;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers {

    [Route ("api/[controller]")]
    public class GrupoUsuarioController : Controller {
        private readonly IGrupoUsuario _grupoUsuario;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GrupoUsuarioController (IConfiguration configuration,
            IMapper mapper, IGrupoUsuario grupoUsuario) {
            _configuration = configuration;
            _mapper = mapper;
            _grupoUsuario = grupoUsuario;
        }

        [HttpGet ("Listar")]
        public async Task<IActionResult> ListarActivos () {

            var grupoUsuarioLista = await _grupoUsuario.ListarGrupoUsuarioActivos ();

            var grupoUsuarioReturn = _mapper.Map<IEnumerable<GrupoUsuarioListaDto>> (grupoUsuarioLista);

            return Ok (grupoUsuarioReturn);
        }

    }
}