using SistemaMedicoApp.Domain.Models.Entities;

namespace SistemaMedicoApp.Domain.Models.Interfaces.Repositories
{
    /// <summary>
    /// Interface para o repositório de paciente.
    /// </summary>
    public interface IPacienteRepository
    {
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task<bool> DeleteAsync(int id);
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
    }
}

