using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Domain.Models.Dtos.Responses
{
    public class PacienteResponseDto
    {
        #region Propriedades  

        [Required(ErrorMessage = "O identificador do paciente é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do paciente deve ser um valor válido.")]
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome do paciente é obrigatório.")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "O nome deve ter entre 6 e 150 caracteres.")]
        public string Nome { get; set; } = null!; 

        [Required(ErrorMessage = "O gênero do paciente é obrigatório.")]
        public int? Genero { get; set; } 

        [Required(ErrorMessage = "A data de nascimento do paciente é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve estar no formato válido.")]
        public DateTime DataNascimento { get; set; } 

        [Required(ErrorMessage = "O endereço do paciente é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço pode ter no máximo 200 caracteres.")]
        public string Endereco { get; set; } = null!;

        [Required(ErrorMessage = "O pedido de exame é obrigatório.")]
        public List<int>? Pedido { get; set; } = null;

        #endregion
    }
}
