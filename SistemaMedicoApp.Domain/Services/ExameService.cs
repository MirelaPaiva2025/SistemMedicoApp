using Newtonsoft.Json;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Enums;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using System.Xml.Linq;

namespace SistemaMedicoApp.Domain.Services
{
    public class ExameService : IExameService
    {
        private readonly IExameRepository _exameRepository;

        public ExameService(IExameRepository exameRepository)
        {
            _exameRepository = exameRepository;
        }

        public async Task<ExameResponseDto> IncluirAsync(ExameRequestDto dto)
        {
            #region Capturar os dados do exame

            var exame = new Exame
            {
                Descricao = dto.Descricao,
                TipoExame = dto.TipoExame,
                DataExame = dto.DataExame,
                DataEntregaResultado = dto.DataEntregaResultado,
                SituacaoExame = dto.SituacaoExame,
                Observacoes = dto.Observacoes,
            };

            #endregion

            #region Realizar o cadastro do exame

            await _exameRepository.AddAsync(exame); 

            return new ExameResponseDto
            {
                Id = exame.Id,
                Descricao = exame.Descricao,
                TipoExame = exame.TipoExame,
                DataExame = exame.DataExame,
                DataEntregaResultado = exame.DataEntregaResultado,
                SituacaoExame = exame.SituacaoExame,
                Observacoes = exame.Observacoes,
            };

            #endregion
        }


        public async Task<ExameResponseDto> AlterarAsync(int id, ExameRequestDto dto)
        {
            #region Buscar o exame no banco de dados através do ID

            var exame = await _exameRepository.GetByIdAsync(id);
            if (exame == null)
                throw new InvalidOperationException($"Exame com ID {id} não encontrado.");

            #endregion

            #region Atribuir os dados do exame

            exame.Descricao = dto.Descricao;
            exame.TipoExame = dto.TipoExame;
            exame.DataExame = dto.DataExame;
            exame.DataEntregaResultado = dto.DataEntregaResultado;
            exame.SituacaoExame = dto.SituacaoExame;
            exame.Observacoes = dto.Observacoes;

            #endregion

            #region Realizar o atualização do exame

            await _exameRepository.UpdateAsync(exame);

            return new ExameResponseDto
            {
                Id = exame.Id,
                Descricao = exame.Descricao,
                TipoExame = exame.TipoExame,
                DataExame = exame.DataExame,
                DataEntregaResultado = exame.DataEntregaResultado,
                SituacaoExame = exame.SituacaoExame,
                Observacoes = exame.Observacoes,
            };

            #endregion
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            #region Buscar o exame no banco de dados através do ID

            var exame = await _exameRepository.GetByIdAsync(id);
            if (exame == null)
                throw new InvalidOperationException($"Exame com ID {id} não encontrado.");

            #endregion

            await _exameRepository.DeleteAsync(id);
            return true; 

        }

        public async Task<List<ExameResponseDto>> ConsultarAsync()
        {
            var response = new List<ExameResponseDto>();
            var exames = await _exameRepository.GetAllAsync();

            foreach (var item in exames)
            {
                response.Add(new ExameResponseDto
                {
                    Id = item.Id,
                    Descricao = item.Descricao ?? string.Empty,
                    TipoExame = item.TipoExame ?? string.Empty,
                    DataExame = item.DataExame,
                    DataEntregaResultado = item.DataEntregaResultado,
                    SituacaoExame = item.SituacaoExame,
                    Observacoes = item.Observacoes,
                });
            }
            return response;
        }

        public async Task<ExameResponseDto> ObterPorIdAsync(int id)
        {
            var exame = await _exameRepository.GetByIdAsync(id);

            if (exame == null)
                throw new InvalidOperationException($"Exame com ID {id} não encontrado.");

            return new ExameResponseDto
            {
                Id = exame.Id,
                Descricao = exame.Descricao ?? string.Empty,
                TipoExame = exame.TipoExame ?? string.Empty,
                DataExame = exame.DataExame,
                DataEntregaResultado = exame.DataEntregaResultado,
                SituacaoExame = exame.SituacaoExame,
                Observacoes = exame.Observacoes,
            };
         }
    }
}
