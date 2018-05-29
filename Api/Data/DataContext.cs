using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<Fase> Fase { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public DbSet<ProgramacionJuego> ProgramacionJuego { get; set; }
        public DbSet<Apuesta> Apuesta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioGrupoUsuario> UsuarioGrupoUsuario { get; set; }
    }
}