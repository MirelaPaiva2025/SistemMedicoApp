using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Dtos.Responses
{
    public class ItensPedidoExameResponseDto
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do pedido de exame é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do pedido de exame deve ser um número positivo.")]
        public int PedidoExameId { get; set; }

        [Required(ErrorMessage = "O ID do exame é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do exame deve ser um número positivo.")]
        public int ExameId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser um número positivo.")]
        public int? Quantidade { get; set; }

        [StringLength(255, ErrorMessage = "O campo Observações não pode exceder 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;
    }
}
