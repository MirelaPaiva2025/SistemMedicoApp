using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;

namespace SistemaMedicoApp.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<PacienteResponseDto> IncluirAsync(PacienteRequestDto dto);
        Task<PacienteResponseDto> AlterarAsync(int id, PacienteRequestDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<List<PacienteResponseDto>> ConsultarAsync();
        Task<PacienteResponseDto> ObterPorIdAsync(int id);
    }
}
