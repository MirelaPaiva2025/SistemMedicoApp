using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade 'ItensPedidoExame'
    /// </summary>
    public class ItensPedidoExameMap : IEntityTypeConfiguration<ItensPedidoExame>
    {
        public void Configure(EntityTypeBuilder<ItensPedidoExame> builder)
        {
            // Nome da tabela
            builder.ToTable("ITENSPEDIDOEXAME");

            // Definindo a chave primária
            builder.HasKey(ipe => ipe.Id);

            // Mapeamento da propriedade 'Id'
            builder.Property(ipe => ipe.Id)
                .HasColumnName("ID");

            // Mapeamento da propriedade 'PedidoExameId'
            builder.Property(ipe => ipe.PedidoExameId)
                .HasColumnName("PEDIDOEXAMEID")
                .IsRequired();

            // Mapeamento da propriedade 'ExameId'
            builder.Property(ipe => ipe.ExameId)
                .HasColumnName("EXAMEID")
                .IsRequired();

            // Mapeamento da propriedade 'Observacoes'
            builder.Property(ipe => ipe.Observacoes)
                .HasColumnName("OBSERVACOES")
                .HasMaxLength(255)
                .IsRequired();

            // Configuração de relacionamentos
            builder.HasOne(ipe => ipe.PedidoExame) 
                .WithMany(pe => pe.ItensPedidoExame)
                .HasForeignKey(ipe => ipe.PedidoExameId);

            builder.HasOne(ipe => ipe.Exame) // Relacionamento com 'Exame'
                .WithMany(e => e.ItensPedidoExame)
                .HasForeignKey(ipe => ipe.ExameId);
        }
    }
}
