using Microsoft.EntityFrameworkCore;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Infra.Data.Context;


namespace SistemaMedicoApp.Infra.Data.Repositories
{
    public class ExameRepository : IExameRepository
    {
        private readonly DataContext _dataContext;

        public ExameRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(Exame exame)
        {
            await _dataContext.AddAsync(exame);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Exame exame)
        {
            _dataContext.Update(exame);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exame = await _dataContext.Set<Exame>().FindAsync(id);
            if (exame == null)
                return false;

            _dataContext.Set<Exame>().Remove(exame);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Exame>> GetAllAsync()
        {
            return await _dataContext.Set<Exame>()
                .OrderBy(p => p.Descricao)
                .ToListAsync();
        }

        public async Task<Exame> GetByIdAsync(int id)
        {
            var exame = await _dataContext.Set<Exame>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (exame == null)
                throw new InvalidOperationException($"Exame com ID {id} não encontrado.");

            return exame;
        }

    }
}
