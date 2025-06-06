using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMedicoApp.Domain.Models.Responses
{
    public class PedidoExameResponseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O ID do exame é obrigatório.")]
        public int ExameId { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "A 'Data do Pedido' deve ser um formato de data válido.")]
        public DateTime? DataPedido { get; set; } 

        [Required(ErrorMessage = "O nome do médico solicitante é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do médico solicitante não pode ultrapassar 100 caracteres.")]

        public string MedicoSolicitante { get; set; } = null!;

        [Required(ErrorMessage = "O status da situação do pedido exame é obrigatório.")]
        public int? SituacaoPedidoExame { get; set; }

        [MaxLength(255, ErrorMessage = "Observações não podem exceder 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;

        public List<int>? ItensPedidoExames { get; set; } = new List<int>();
    }
}