using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SistemaMedicoApp.Tests
{
    public class PacienteTesteUnitario
    {
        [Fact]
        public void PacienteValido()
        {
            // Arrange
            var paciente = new Paciente
            {
                Id = 1,
                Nome = "Maria Silva",
                Genero = GeneroPaciente.Feminino,
                DataNascimento = new DateTime(1990, 5, 15),
                Endereco = "Rua das Flores, 123"
            };

            // Act
            var resultadoEhValido = ValidaEntidade(paciente);

            // Assert
            Assert.True(resultadoEhValido);
        }

        [Fact]
        public void PacienteInvalidoSemNome()
        {
            // Arrange
            var paciente = new Paciente
            {
                Id = 1,
                Nome = null!, // Nome ausente
                Genero = GeneroPaciente.Masculino,
                DataNascimento = new DateTime(1985, 3, 20),
                Endereco = "Rua da Paz, 456"
            };

            // Act
            var resultadoEhValido = ValidaEntidade(paciente);

            // Assert
            Assert.False(resultadoEhValido);
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
