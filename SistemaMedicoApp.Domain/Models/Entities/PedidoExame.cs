using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Entities
{
    public class PedidoExame
    {
        #region Propriedades

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o paciente.")]
        public int PacienteId { get; set; } // Chave estrangeira

        [Required(ErrorMessage = "Informe o exame.")]
        public int ExameId { get; set; } 

        [Required(ErrorMessage = "Informe a data do pedido.")]
        [DataType(DataType.DateTime, ErrorMessage = "A data do pedido deve estar em um formato válido.")]
        public DateTime? DataPedido { get; set; }

        [Required(ErrorMessage = "Informe o nome do médico solicitante.")]
        public string MedicoSolicitante { get; set; } = null!;

        [Required(ErrorMessage = "Informe o status do pedido.")]
        public int? SituacaoPedidoExame { get; set; } // Status do pedido (ex.: 1-Pendente, 2-Concluído, 3-Cancelado)

        [MaxLength(255, ErrorMessage = "As observações não podem ultrapassar 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion

        #region Relacionamentos

        [Required(ErrorMessage = "Informe o pedido de exame relacionado ao pedido.")]
        public Paciente Paciente { get; set; } = null!;

        public ICollection<ItensPedidoExame> ItensPedidoExame { get; set; } = new List<ItensPedidoExame>();

        #endregion
    }
}
