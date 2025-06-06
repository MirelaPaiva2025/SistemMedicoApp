using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Dtos.Responses
{
    public class ExameResponseDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição do exame é obrigatória.")]
        [StringLength(150, ErrorMessage = "A descrição do exame não pode exceder 150 caracteres.")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de exame é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tipo de exame não pode exceder 50 caracteres.")]
        public string TipoExame { get; set; } = null!;

        [Required(ErrorMessage = "A data do exame é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data do exame é inválido.")]
        public DateTime? DataExame { get; set; }

        [Required(ErrorMessage = "A data de entrega do resultado é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data de entrega do resultado é inválido.")]
        public DateTime? DataEntregaResultado { get; set; }

        [Required(ErrorMessage = "O status do exame é obrigatório (Pendente, Realizado, Cancelado).")]
        public int? SituacaoExame { get; set; }

        [StringLength(255, ErrorMessage = "As observações não podem exceder 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;
    }
}
