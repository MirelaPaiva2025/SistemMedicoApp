using Microsoft.EntityFrameworkCore;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Infra.Data.Context;


namespace SistemaMedicoApp.Infra.Data.Repositories
{
    public class PedidoExameRepository : IPedidoExameRepository
    {
        private readonly DataContext _dataContext;

        public PedidoExameRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(PedidoExame pedido)
        {
            await _dataContext.AddAsync(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PedidoExame pedido)
        {
            _dataContext.Update(pedido);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await _dataContext.Set<PedidoExame>().FindAsync(id);
            if (pedido == null)
                return false;

            _dataContext.Set<PedidoExame>().Remove(pedido);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<PedidoExame>> GetAllAsync()
        {
            return await _dataContext.Set<PedidoExame>()
                .ToListAsync();
        }

        public async Task<PedidoExame> GetByIdAsync(int id)
        {
            var pedido = await _dataContext.Set<PedidoExame>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                throw new InvalidOperationException($"Pedido de Exame com ID {id} não encontrado.");

            return pedido;
        }

    }
}

