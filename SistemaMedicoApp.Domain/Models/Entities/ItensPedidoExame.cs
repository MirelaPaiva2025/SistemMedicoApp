using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Entities
{
    public class ItensPedidoExame
    {
        #region Propriedades

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o identificador do pedido de exame.")]
        public int PedidoExameId { get; set; }

        [Required(ErrorMessage = "Informe o identificador do exame.")]
        public int ExameId { get; set; }  // Chave estrangeira

        [Required(ErrorMessage = "Informe a quantidade.")]
        public int? Quantidade { get; set; }

        [StringLength(255, ErrorMessage = "Observações não podem exceder 255 caracteres.")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion

        #region Relacionamentos

        [Required(ErrorMessage = "Informe o Pedido de Exame.")]
        public PedidoExame PedidoExame { get; set; } = null!;

        [Required(ErrorMessage = "Informe o Exame.")]
        public Exame Exame { get; set; } = null!;

        #endregion
    }
}
