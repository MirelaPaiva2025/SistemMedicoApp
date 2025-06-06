using Microsoft.EntityFrameworkCore;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Infra.Data.Context;


namespace SistemaMedicoApp.Infra.Data.Repositories
{
    public class ItensPedidoExameRepository : IItensPedidoExameRepository
    {
        private readonly DataContext _dataContext;

        public ItensPedidoExameRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(ItensPedidoExame itens)
        {
            await _dataContext.AddAsync(itens);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItensPedidoExame itens)
        {
            _dataContext.Update(itens);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var itens = await _dataContext.Set<ItensPedidoExame>().FindAsync(id);
            if (itens == null)
                return false;

            _dataContext.Set<ItensPedidoExame>().Remove(itens);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ItensPedidoExame>> GetAllAsync()
        {
            return await _dataContext.Set<ItensPedidoExame>()
                .ToListAsync();
        }

        public async Task<ItensPedidoExame> GetByIdAsync(int id)
        {
            var itens = await _dataContext.Set<ItensPedidoExame>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (itens == null)
                throw new InvalidOperationException($"Itens Pedido de Exame com ID {id} não encontrado.");

            return itens;
        }

    }
}


