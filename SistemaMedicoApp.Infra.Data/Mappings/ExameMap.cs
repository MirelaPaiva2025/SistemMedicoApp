using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade 'Exame'
    /// </summary>
    public class ExameMap : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            // Nome da tabela
            builder.ToTable("EXAME");

            // Definindo a chave primária
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("ID");

            builder.Property(e => e.Descricao)
                .HasColumnName("DESCRICAO")
                .IsRequired();

            builder.Property(e => e.TipoExame)
                .HasColumnName("TIPOEXAME")
                .IsRequired();

            builder.Property(e => e.DataExame)
                .HasColumnName("DATAEXAME")
                .IsRequired();

            builder.Property(e => e.DataEntregaResultado)
                .HasColumnName("DATAENTREGARESULTADO")
                .IsRequired();

            builder.Property(e => e.SituacaoExame)
                .HasColumnName("STATUSEXAME")
                .IsRequired();

            builder.Property(e => e.Observacoes)
                .HasColumnName("OBSERVACOES")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(e => e.ItensPedidoExame) 
                .WithOne(ipe => ipe.Exame)
                .HasForeignKey(ipe => ipe.ExameId);
        }
    }
}
