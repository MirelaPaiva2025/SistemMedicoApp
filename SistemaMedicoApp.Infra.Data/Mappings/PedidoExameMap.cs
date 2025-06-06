using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaMedicoApp.Domain.Models.Entities;
using System.Reflection.Emit;

namespace SistemaMedicoApp.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade 'PedidoExame'
    /// </summary>
    public class PedidoExameMap : IEntityTypeConfiguration<PedidoExame>
    {
        public void Configure(EntityTypeBuilder<PedidoExame> builder)
        {
            // Nome da tabela
            builder.ToTable("PEDIDOEXAME");

            // Definindo a chave primária
            builder.HasKey(pe => pe.Id);

            // Mapeamento da propriedade 'Id'
            builder.Property(pe => pe.Id)
                .HasColumnName("ID");

            // Mapeamento da propriedade 'PacienteId'
            builder.Property(pe => pe.PacienteId)
                .HasColumnName("PACIENTEID")
                .IsRequired();

            // Mapeamento da propriedade 'DataPedido'
            builder.Property(pe => pe.DataPedido)
                .HasColumnName("DATAPEDIDO")
                .IsRequired();

            // Mapeamento da propriedade 'MedicoSolicitante'
            builder.Property(pe => pe.MedicoSolicitante)
                .HasColumnName("MEDICOSOLICITANTE")
                .HasMaxLength(100)
                .IsRequired();

            // Mapeamento da propriedade 'Observacoes'
            builder.Property(pe => pe.Observacoes)
                .HasColumnName("OBSERVACOES")
                .HasMaxLength(255);

            // Mapeamento da propriedade 'Status'
            builder.Property(pe => pe.SituacaoPedidoExame)
                .HasColumnName("SITUACAOPEDIDOEXAME")
                .IsRequired();

            // Configuração de relacionamentos
            builder.HasOne(pe => pe.Paciente) 
                .WithMany(p => p.Pedidos)
                .HasForeignKey(pe => pe.PacienteId);

            builder.HasMany(pe => pe.ItensPedidoExame) 
                .WithOne(ipe => ipe.PedidoExame)
                .HasForeignKey(ipe => ipe.PedidoExameId);
        }
    }
}
