using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;

namespace SistemaMedicoApp.Domain.Interfaces.Services
{
    public interface IItensPedidoExameService
    {
        Task<ItensPedidoExameResponseDto> IncluirAsync(ItensPedidoExameRequestDto dto);
        Task<ItensPedidoExameResponseDto> AlterarAsync(int id, ItensPedidoExameRequestDto dto);
        Task<bool> ExcluirAsync(int id);
        Task<List<ItensPedidoExameResponseDto>> ConsultarAsync();
        Task<ItensPedidoExameResponseDto> ObterPorIdAsync(int id);
    }
}

