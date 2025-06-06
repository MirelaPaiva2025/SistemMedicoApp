using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Dtos.Requests
{
    public class PedidoExameRequestDto
    {
        #region Propriedades

        [Required(ErrorMessage = "O ID do paciente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do paciente deve ser um número positivo.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O ID do exame é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do exame deve ser um número positivo.")]
        public int ExameId { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Data do pedido inválida.")]
        public DateTime? DataPedido { get; set; } 

        [Required(ErrorMessage = "O nome do médico solicitante é obrigatório.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O nome do médico deve ter entre 3 e 150 caracteres.")]
        public string MedicoSolicitante { get; set; } = string.Empty;

        [Required(ErrorMessage = "O status da situação do pedido exame é obrigatório.")]
        public int? SituacaoPedidoExame { get; set; } // Status do pedido (ex.: 1-Pendente, 2-Concluído, 3-Cancelado)

        [StringLength(255, ErrorMessage = "As observações devem ter no máximo 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;

        public List<int>? ItensPedidoExames { get; set; } = new List<int>(); 

        public PedidoExameRequestDto(int pacienteId,
                                     int exameId,
                                     DateTime? dataPedido,
                                     string nomeSolicitante,
                                     int? situacaoPedidoExame, 
                                     List<int> itensPedidoExame,
                                     string observacoes)
        {
            PacienteId = pacienteId;
            ExameId = exameId;
            DataPedido = dataPedido;
            MedicoSolicitante = nomeSolicitante;
            SituacaoPedidoExame = situacaoPedidoExame;
            ItensPedidoExames = itensPedidoExame;
            Observacoes = observacoes;
        }

        #endregion
    }
}
