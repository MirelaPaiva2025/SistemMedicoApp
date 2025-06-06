using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Domain.Models.Interfaces.Repositories
{
    /// <summary>
    /// Interface para o repositório de exame.
    /// </summary>
    public interface IExameRepository
    {
        Task AddAsync(Exame exame);
        Task UpdateAsync(Exame exame);
        Task<bool> DeleteAsync(int id);
        Task<List<Exame>> GetAllAsync();
        Task<Exame> GetByIdAsync(int id);
    }
}

