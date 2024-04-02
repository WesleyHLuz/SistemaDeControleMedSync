using Microsoft.EntityFrameworkCore;
using SistemaDeControleMedSync.API.Entities;
using SistemaDeControleMedSync.API.ValueObject;

namespace SistemaDeControleMedSync.API.Context
{
    public class DefaultContext: DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicoEspecialidade>().HasKey(x => new { x.MedicoId, x.EspecialidadeId });
            modelBuilder.Entity<Cpf>().HasNoKey();
            modelBuilder.Entity<Email>().HasNoKey();

            
        }

        

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Convenio> Convenios { get; set;}
        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Especialidade> Especialidades { get; set;}
        public DbSet<MedicoEspecialidade> MedicoEspecialidades { get; set;}
    } 

}
