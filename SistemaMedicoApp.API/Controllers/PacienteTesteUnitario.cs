using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace SistemaMedicoApp.API.Controllers
{
    public class PacienteTesteUnitario
    {
        [Fact]
        public void PacienteValido()
        {
            var paciente = new Paciente
            {
                Id = 1,
                Nome = "Maria Silva",
                Genero = GeneroPaciente.Feminino,
                DataNascimento = new DateTime(1990, 5, 15),
                Endereco = "Rua das Flores, 123"
            };

            var resultadoValido = ValidaEntidade(paciente);

            Assert.True(resultadoValido);
        }

        [Fact]
        public void PacienteInvalidoSemNome()
        {
            var paciente = new Paciente
            {
                Id = 1,
                Nome = null!, 
                Genero = GeneroPaciente.Masculino,
                DataNascimento = new DateTime(1985, 3, 20),
                Endereco = "Rua da Paz, 456"
            };

            var resultadoValido = ValidaEntidade(paciente);

            Assert.False(resultadoValido);
        }

        // Método auxiliar para validação
        private bool ValidaEntidade(Paciente paciente)
        {
            var context = new ValidationContext(paciente, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(paciente, context, results, true);
        }
    }
}
