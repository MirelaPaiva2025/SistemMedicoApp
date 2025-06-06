using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Domain.Models.Interfaces.Repositories
{
    /// <summary>
    /// Interface para o repositório de itens pedido de exame.
    /// </summary>
    public interface IItensPedidoExameRepository
    {
        Task AddAsync(ItensPedidoExame itenspedido);
        Task UpdateAsync(ItensPedidoExame itenspedido);
        Task<bool> DeleteAsync(int id);
        Task<List<ItensPedidoExame>> GetAllAsync();
        Task<ItensPedidoExame> GetByIdAsync(int id);
    }
}
