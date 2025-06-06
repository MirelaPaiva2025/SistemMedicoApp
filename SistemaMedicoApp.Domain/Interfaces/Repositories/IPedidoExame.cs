using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Domain.Models.Interfaces.Repositories
{
    /// <summary>
    /// Interface para o repositório de pedido de exame.
    /// </summary>
    public interface IPedidoExameRepository
    {
        Task AddAsync(PedidoExame pedido);
        Task UpdateAsync(PedidoExame pedido);
        Task<bool> DeleteAsync(int id);
        Task<List<PedidoExame>> GetAllAsync();
        Task<PedidoExame> GetByIdAsync(int id);
    }
}