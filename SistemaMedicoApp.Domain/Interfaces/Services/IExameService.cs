using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;

namespace SistemaMedicoApp.Domain.Interfaces.Services
{
    public interface IExameService
    {
        Task<ExameResponseDto> IncluirAsync(ExameRequestDto dto);
        Task<ExameResponseDto> AlterarAsync(int id, ExameRequestDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<List<ExameResponseDto>> ConsultarAsync();
        Task<ExameResponseDto> ObterPorIdAsync(int id);
    }     
}