using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Domain.Models.Enums;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;

namespace SistemaMedicoApp.Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<PacienteResponseDto> IncluirAsync(PacienteRequestDto dto)
        {
            #region Capturar os dados do paciente

            var paciente = new Paciente
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento, 
                Endereco = dto.Endereco,
                Genero = dto.Genero,
            };

            #endregion

            #region Gravar o paciente no banco de dados

            await _pacienteRepository.AddAsync(paciente);

            #endregion

            #region Realizar o cadastro do paciente

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento ?? DateTime.MinValue,
                Endereco = paciente.Endereco,
                Genero = paciente.Genero,
            };

            #endregion
        }

        public async Task<PacienteResponseDto> AlterarAsync(int id, PacienteRequestDto dto)
        {
            #region Buscar o paciente no banco de dados através do ID

            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
                throw new ApplicationException("Paciente não encontrado, verifique o ID informado.");

            #endregion

            #region Atribuir os dados do paciente

            paciente.Nome = dto.Nome;
            paciente.DataNascimento = dto.DataNascimento; // Certifique-se de que `dto.DataNascimento` seja do tipo correto
            paciente.Endereco = dto.Endereco;
            paciente.Genero = dto.Genero;

            #endregion

            #region Realizar o atualização do paciente

            await _pacienteRepository.UpdateAsync(paciente);

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                DataNascimento = paciente.DataNascimento ?? DateTime.MinValue,
                Endereco = paciente.Endereco,
                Genero = (int)(paciente.Genero ?? 0),
            };

            #endregion
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            #region Buscar o paciente no banco de dados através do ID

            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
                throw new ApplicationException("Paciente não encontrado, verifique o ID informado.");

            #endregion

            await _pacienteRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<PacienteResponseDto>> ConsultarAsync()
        {
            var response = new List<PacienteResponseDto>();
            var pacientes = await _pacienteRepository.GetAllAsync();

            foreach (var item in pacientes)
            {
                response.Add(new PacienteResponseDto
                {
                    Id = item.Id,
                    Nome = item.Nome ?? string.Empty,
                    DataNascimento = item.DataNascimento ?? DateTime.MinValue,
                    Endereco = item.Endereco ?? string.Empty,
                    Genero = (int)(item.Genero ?? 0),
                });
            }

            return response;
        }

        public async Task<PacienteResponseDto> ObterPorIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
                throw new ApplicationException("Paciente não encontrado, verifique o ID informado.");

            return new PacienteResponseDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome ?? string.Empty,
                DataNascimento = paciente.DataNascimento ?? DateTime.MinValue,
                Endereco = paciente.Endereco ?? string.Empty,
                Genero = (int)(paciente.Genero ?? 0),
            };
        }
    }
}