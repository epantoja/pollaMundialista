using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Dto;
using Api.Interface;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers {
    [Route ("api/[controller]")]
    public class UsuarioController : Controller {
        private readonly IUsuario _usuario;
        private readonly IGrupoUsuario _grupoUsuario;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioController (IConfiguration configuration,
            IMapper mapper, IUsuario usuario, IGrupoUsuario grupoUsuario) {
            _configuration = configuration;
            _mapper = mapper;
            _usuario = usuario;
            _grupoUsuario = grupoUsuario;
        }

        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] UsuarioRegisterDto usuarioRegisterDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var usuarioRegistro = new Usuario {
                CodUsuario = usuarioRegisterDto.CodUsuario,
                Nombres = usuarioRegisterDto.Nombres
            };

            var usuarioGrupoUsuario = new UsuarioGrupoUsuario {
                GrupoUsuarioId = usuarioRegisterDto.GrupoUsuarioId
            };

            if (!string.IsNullOrEmpty (usuarioRegisterDto.CodUsuario))
                usuarioRegisterDto.CodUsuario = usuarioRegisterDto.CodUsuario.ToLower ();

            if (usuarioRegisterDto.GrupoUsuarioId == 1)
                ModelState.AddModelError ("GrupoUsuarioId", "No de puede crear el usuario con este grupo");

            if (await _grupoUsuario.ObtenerGrupoUsuario (new GrupoUsuario { Id = usuarioRegisterDto.GrupoUsuarioId }) == null)
                ModelState.AddModelError ("GrupoUsuarioId", "El Grupo no existe");

            if (await _usuario.VerificarUsuario (usuarioRegistro) != null)
                ModelState.AddModelError ("CodLogin", "Usuario ya existe");

            var userCreate = await _usuario.GuardarUsuario (usuarioRegisterDto.Contrasena, usuarioRegistro, usuarioGrupoUsuario);

            return StatusCode (201);
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Login ([FromBody] UsuarioLoginDto usuarioLoginDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            if (usuarioLoginDto == null)
                return Unauthorized ();

            var usuarioLogin = new Usuario {
                CodUsuario = usuarioLoginDto.CodUsuario
            };

            var usuarioGrupoUsuario = new UsuarioGrupoUsuario {
                GrupoUsuarioId = usuarioLoginDto.GrupoUsuarioId
            };

            var userFromRepo = await _usuario.LoginUsuario (usuarioLoginDto.Contrasena, usuarioLogin, usuarioGrupoUsuario);

            if (userFromRepo == null)
                return Unauthorized ();

            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes (_configuration.GetSection ("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (new Claim[] {
                new Claim (ClaimTypes.NameIdentifier, userFromRepo.Id.ToString ()),
                new Claim (ClaimTypes.Name, userFromRepo.CodUsuario),
                new Claim (ClaimTypes.Role, usuarioLoginDto.GrupoUsuarioId.ToString ())
                }),
                Expires = DateTime.Now.AddDays (1),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);
            var tokenString = tokenHandler.WriteToken (token);

            return Ok (new { tokenString });
        }

        [Authorize]
        [HttpGet ("Obtener/{Id}")]
        public async Task<IActionResult> ObtenerUsuario (int Id) {

            var usuario = new Usuario {
                Id = Id
            };

            var consulGrupoUsuario = new GrupoUsuario {
                Id = int.Parse (User.FindFirst (ClaimTypes.Role).Value)
            };

            var usuarioResult = await _usuario.ObtenerUsuario (usuario);

            var usuarioMapper = _mapper.Map<DetalleUsuarioDto> (usuarioResult);

            usuarioMapper.GrupoActual = _mapper.Map<GrupoUsuarioListaDto> (await _grupoUsuario.ObtenerGrupoUsuario (consulGrupoUsuario));

            return Ok (usuarioMapper);
        }

        [Authorize]
        [HttpPut ("ActualizarUsuario/{id}")]
        public async Task<IActionResult> ActualizarUsuario (int id, [FromBody] UsuarioActualizarDto usuarioActualizarDto) {
            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            var currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _usuario.ObtenerUsuario (new Usuario { Id = id });

            if (userFromRepo == null)
                return NotFound ($"No se pido encontrar el usuario con el ID {id}");

            if (currentUserId != userFromRepo.Id)
                return Unauthorized ();

            _mapper.Map (usuarioActualizarDto, userFromRepo);

            if (await _usuario.ActualizarUsuario (userFromRepo))
                return NoContent ();

            throw new Exception ($"Actualizacion del usuario {id} Fallo");
        }

        [Authorize]
        [HttpPut ("ActualizarClave/{id}")]
        public async Task<IActionResult> ActualizarClave (int id, [FromBody] UsuarioClaveDto UsuarioClaveDto) {

            if (!ModelState.IsValid)
                return BadRequest (ModelState);

            if (UsuarioClaveDto.ContrasenaNueva != UsuarioClaveDto.ConfirmarContrasena)
                ModelState.AddModelError ("ContrasenaNueva", "Las contrasenas no son iguales");

            var currentUserId = int.Parse (User.FindFirst (ClaimTypes.NameIdentifier).Value);

            var userFromRepo = await _usuario.ObtenerUsuario (new Usuario { Id = id });

            if (userFromRepo == null)
                return NotFound ($"No se pido encontrar el usuario con el ID {id}");

            if (currentUserId != userFromRepo.Id)
                return Unauthorized ();

            var usuarioGrupoUsuario = new UsuarioGrupoUsuario {
                GrupoUsuarioId = int.Parse (User.FindFirst (ClaimTypes.Role).Value)
            };

            var userFromLogin = await _usuario.LoginUsuario (UsuarioClaveDto.Contrasena, userFromRepo, usuarioGrupoUsuario);

            if (userFromLogin == null)
                return Unauthorized ();

            if (await _usuario.ActualizarClaveUsuario (userFromRepo.Id, UsuarioClaveDto.ContrasenaNueva))
                return NoContent ();

            throw new Exception ($"Actualizacion del usuario {id} Fallo");
        }
    }
}