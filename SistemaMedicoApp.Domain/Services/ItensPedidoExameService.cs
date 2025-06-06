using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Domain.Models.Enums;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;

namespace SistemaMedicoApp.Domain.Services
{
    public class ItensPedidoExameService : IItensPedidoExameService
    {
        private readonly IItensPedidoExameRepository _itensPedidoExameRepository;

        public ItensPedidoExameService(IItensPedidoExameRepository itensPedidoExameRepository)
        {
            _itensPedidoExameRepository = itensPedidoExameRepository;
        }

        public async Task<ItensPedidoExameResponseDto> IncluirAsync(ItensPedidoExameRequestDto dto)
        {
            #region Capturar os dados do Itens Pedido Exames

            var itensPedidosExames = new ItensPedidoExame
            {
                PedidoExameId = dto.PedidoExameId,
                ExameId = dto.ExameId,
                Quantidade = dto.Quantidade ?? 0,
                Observacoes = dto.Observacoes,
            };

            #endregion

            #region Realizar o cadastro do Itens Pedido Exames

            await _itensPedidoExameRepository.AddAsync(itensPedidosExames);

            return new ItensPedidoExameResponseDto
            {
                Id = itensPedidosExames.Id,
                PedidoExameId = itensPedidosExames.PedidoExameId,
                ExameId = itensPedidosExames.ExameId,
                Quantidade = itensPedidosExames.Quantidade,
                Observacoes = itensPedidosExames.Observacoes,
            };

            #endregion
        }


        public async Task<ItensPedidoExameResponseDto> AlterarAsync(int id, ItensPedidoExameRequestDto dto)
        {
            #region Buscar o itens de Pedido de Exame no banco de dados através do ID

            var itensPedidosExames = await _itensPedidoExameRepository.GetByIdAsync(id);
            if (itensPedidosExames == null)
                throw new ApplicationException("Itens de Pedido de Exame não encontrado, verifique o ID informado.");

            #endregion

            #region Atribuir os dados do itens de Pedido de Exame

            itensPedidosExames.PedidoExameId = dto.PedidoExameId;
            itensPedidosExames.ExameId = dto.ExameId; 
            itensPedidosExames.Quantidade = dto.Quantidade ?? 0; 
            itensPedidosExames.Observacoes = dto.Observacoes;

            #endregion

            #region Realizar o atualização do itens de Pedido de Exame

            await _itensPedidoExameRepository.UpdateAsync(itensPedidosExames);

            return new ItensPedidoExameResponseDto
            {
                Id = itensPedidosExames.Id,
                PedidoExameId = itensPedidosExames.PedidoExameId,
                ExameId = itensPedidosExames.ExameId,
                Quantidade = itensPedidosExames.Quantidade,
                Observacoes = itensPedidosExames.Observacoes,
            };

            #endregion
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            #region Buscar o itens de Pedido de Exame no banco de dados através do ID

            var itensPedidoExameResponseDto = await _itensPedidoExameRepository.GetByIdAsync(id);
            if (itensPedidoExameResponseDto == null)
                throw new ApplicationException("Itens de Pedido de Exame não encontrado, verifique o ID informado.");

            #endregion

            await _itensPedidoExameRepository.DeleteAsync(id);
            return true; 
        }

        public async Task<List<ItensPedidoExameResponseDto>> ConsultarAsync()
        {
            var response = new List<ItensPedidoExameResponseDto>();
            var itensPedidosExames = await _itensPedidoExameRepository.GetAllAsync();

            foreach (var item in itensPedidosExames)
            {
                response.Add(new ItensPedidoExameResponseDto
                {
                    Id = item.Id,
                    PedidoExameId = item.PedidoExameId,
                    ExameId = item.ExameId,
                    Quantidade = item.Quantidade,
                    Observacoes = item.Observacoes,
                });
            }

            return response;
        }

        public async Task<ItensPedidoExameResponseDto> ObterPorIdAsync(int id)
        {
            var itensPedidosExames = await _itensPedidoExameRepository.GetByIdAsync(id);
            if (itensPedidosExames == null)
                throw new ApplicationException("Itens de Pedido de Exame não encontrado, verifique o ID informado.");

            return new ItensPedidoExameResponseDto
            {
                Id = itensPedidosExames.Id,
                PedidoExameId = itensPedidosExames.PedidoExameId,
                ExameId = itensPedidosExames.ExameId,
                Quantidade = itensPedidosExames.Quantidade,
                Observacoes = itensPedidosExames.Observacoes,
            };
        }
    }
}