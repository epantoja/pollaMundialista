using System.Linq;
using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Helpers {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles () {

            CreateMap<Usuario, DetalleUsuarioDto> ();

            CreateMap<GrupoUsuario, GrupoUsuarioListaDto> ();

            CreateMap<UsuarioActualizarDto, Usuario> ();

            CreateMap<UsuarioClaveDto, Usuario> ();

            CreateMap<Equipo, EquipoRegistroDto> ();

            CreateMap<EquipoRegistroDto, Equipo> ();

            CreateMap<EquipoDetalleDto, Equipo> ();

            CreateMap<Equipo, EquipoDetalleDto> ();

            CreateMap<Equipo, ActualizarEquipoDto> ();

            CreateMap<ActualizarEquipoDto, Equipo> ();

            CreateMap<Equipo, EquipoListaDto> ();

            CreateMap<Fase, FaseListaDto> ();

            CreateMap<ProgramacionJuego, ProgramacionJuegoListaDto> ();

            CreateMap<ProgramacionJuegoRegistroDto, ProgramacionJuego> ();
        }
    }
}