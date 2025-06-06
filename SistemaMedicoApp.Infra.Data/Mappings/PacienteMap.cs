using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Data.Mappings
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("PACIENTE");

            //definindo o campo 'chave primária'
            builder.HasKey(p => p.Id);

            //mapeamento do campo 'id'
            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO")
                .IsRequired();           
           
            builder.Property(p => p.Endereco)
                .HasColumnName("ENDERECO")
                .HasMaxLength(200);

            builder.Property(p => p.Genero)
                .HasColumnName("GENERO")
                .IsRequired();            
        }
    }
}
