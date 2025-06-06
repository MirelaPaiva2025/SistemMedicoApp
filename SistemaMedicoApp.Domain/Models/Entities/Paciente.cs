using SistemaMedicoApp.Domain.Models.Enums;
using SistemaMedicoApp.Domain.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace SistemaMedicoApp.Domain.Models.Entities
{
    public class Paciente
    {
        [Key]
        public int Id { get; init; }

        [Required(ErrorMessage = "Informe o nome do paciente.")]
        public string? Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a data de Nascimento do paciente.")]
        [DataType(DataType.Date)]
        [Column("DATANASCIMENTO")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o endereço do paciente.")]
        public string? Endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = " Informe o gênero do paciente. (Masculino, Ferminino, Binário, Outros).")]
        public int? Genero { get; set; }

        public ICollection<PedidoExame>? Pedidos { get; set; }
    }

}
