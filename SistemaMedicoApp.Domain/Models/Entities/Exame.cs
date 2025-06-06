using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaMedicoApp.Domain.Models.Entities
{
    public class Exame
    {
        #region Propriedades 

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do exame.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = " Informe o tipo de exame.")]

        public string TipoExame { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a data do exame.")]
        [DataType(DataType.DateTime)]
        public DateTime? DataExame { get; set; }

        [Required(ErrorMessage = "Informe a data de entrega do resultado.")]
        [DataType(DataType.DateTime)]
        public DateTime? DataEntregaResultado { get; set; }

        [Required(ErrorMessage = " Informe o status do exame  (Pendente, Realizado, Cancelado).")]
        public int? SituacaoExame { get; set; }  // Pendente = 1,Realizado = 2,Cancelado = 3

        [Required(ErrorMessage = "Informe as Observações.")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion

        #region Relacionamentos

        public ICollection<ItensPedidoExame> ItensPedidoExame { get; set; } = new List<ItensPedidoExame>();
     

        #endregion
    }
}