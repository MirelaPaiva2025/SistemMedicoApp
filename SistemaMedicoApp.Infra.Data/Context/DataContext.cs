using Microsoft.EntityFrameworkCore;
using SistemaMedicoApp.Data.Mappings;
using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        // Construtor para injeção de dependências
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Configuração das tabelas (DbSet)
        public DbSet<Paciente> Pacientes { get; set; } = null!;
        public DbSet<PedidoExame> PedidosExame { get; set; } = null!;
        public DbSet<ItensPedidoExame> ItensPedidoExame { get; set; } = null!;
        public DbSet<Exame> Exames { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBSistemaMedico;Integrated Security=True;",
                    b => b.MigrationsAssembly("SistemaMedicoApp.Infra.Data"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar configurações de mapeamento
            modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfiguration(new PedidoExameMap());
            modelBuilder.ApplyConfiguration(new ExameMap());
            modelBuilder.ApplyConfiguration(new ItensPedidoExameMap());

            // Alternativamente, aplicar todas as configurações do assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
