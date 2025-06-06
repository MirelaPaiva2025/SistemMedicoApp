using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Xml.Linq;

namespace SistemaMedicoApp.Domain.Models.Dtos.Requests
{
    public class PacienteRequestDto
    {
        #region Propriedades

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome do paciente não pode ultrapassar 150 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O gênero do paciente é obrigatório.")]
        public int? Genero { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve estar em um formato válido.")]
        public DateTime? DataNascimento { get; set; } 

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço do paciente não pode ultrapassar 200 caracteres.")]
        public string Endereco { get; set; } = null!;

        #endregion

        #region Relacionamentos

        [Required(ErrorMessage = "O pedido de exame é obrigatório.")]
        public List<PedidoExameRequestDto>? Pedido { get; set; } = null;
        public int PedidoExameId { get; set; }

        #endregion
    }
}