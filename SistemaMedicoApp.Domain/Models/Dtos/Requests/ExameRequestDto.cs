using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMedicoApp.Domain.Models.Dtos.Requests
{
    public class ExameRequestDto
    {
        #region Propriedades 
        
        [Required(ErrorMessage = "A descrição do exame é obrigatória.")]
        [StringLength(150, ErrorMessage = "A descrição do exame deve ter no máximo 150 caracteres.")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de exame é obrigatório.")]
        [StringLength(100, ErrorMessage = "O tipo de exame deve ter no máximo 100 caracteres.")]
        public string TipoExame { get; set; } = null!;

        [Required(ErrorMessage = "A data do exame é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data do exame é inválido.")]
        public DateTime? DataExame { get; set; }

        [Required(ErrorMessage = "A data de entrega do resultado é obrigatória.")]
        [DataType(DataType.DateTime, ErrorMessage = "O formato da data de entrega do resultado é inválido.")]
        public DateTime? DataEntregaResultado { get; set; }

        [Required(ErrorMessage = "O status do exame é obrigatório.")]
        [EnumDataType(typeof(StatusExame), ErrorMessage = "O status do exame informado não é válido.")]
        public int? SituacaoExame { get; set; } // Pendente = 1,  Realizado = 2, Cancelado = 3

        [StringLength(255, ErrorMessage = "As observações devem ter no máximo 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion
    }
 }
