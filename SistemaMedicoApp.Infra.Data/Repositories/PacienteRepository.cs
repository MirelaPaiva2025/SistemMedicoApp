using Microsoft.EntityFrameworkCore;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Infra.Data.Context;


namespace SistemaMedicoApp.Infra.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DataContext _dataContext;

        public PacienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _dataContext.AddAsync(paciente);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _dataContext.Update(paciente);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var paciente = await _dataContext.Set<Paciente>().FindAsync(id);
            if (paciente == null)
                return false;

            _dataContext.Set<Paciente>().Remove(paciente);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            return await _dataContext.Set<Paciente>()
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            var paciente = await _dataContext.Set<Paciente>()
                                             .FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
                throw new InvalidOperationException($"Paciente com ID {id} não encontrado.");

            return paciente;
        }

    }
}
