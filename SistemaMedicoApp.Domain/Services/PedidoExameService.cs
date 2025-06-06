using SistemaMedicoApp.Domain.Models.Dtos.Requests;
using SistemaMedicoApp.Domain.Models.Entities;
using SistemaMedicoApp.Domain.Models.Interfaces.Repositories;
using SistemaMedicoApp.Domain.Models.Enums;
using SistemaMedicoApp.Domain.Interfaces.Services;
using SistemaMedicoApp.Domain.Models.Dtos.Responses;
using SistemaMedicoApp.Domain.Models.Responses;
using System;

namespace SistemaMedicoApp.Domain.Services
{
    public class PedidoExameService : IPedidoExameService
    {
        private readonly IPedidoExameRepository _pedidoRepository;

        public PedidoExameService(IPedidoExameRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoExameResponseDto> IncluirAsync(PedidoExameRequestDto dto)
        {
            #region Capturar os dados do pedido

            var pedido = new PedidoExame
            {
                PacienteId  = dto.PacienteId,
                ExameId     = dto.ExameId,
                DataPedido  = dto.DataPedido,
                Observacoes = dto.Observacoes,
                MedicoSolicitante = dto.MedicoSolicitante,
                SituacaoPedidoExame = (int?)dto.SituacaoPedidoExame,
            };

            #endregion

            #region Realizar o cadastro do pedido

            await _pedidoRepository.AddAsync(pedido);

            return new PedidoExameResponseDto
            {
                Id          = pedido.Id,
                PacienteId  = pedido.PacienteId,
                ExameId     = pedido.ExameId,
                DataPedido  = pedido.DataPedido,
                Observacoes = pedido.Observacoes,
                MedicoSolicitante = pedido.MedicoSolicitante,
                SituacaoPedidoExame = (int?)dto.SituacaoPedidoExame,
            };

            #endregion
        }


        public async Task<PedidoExameResponseDto> AlterarAsync(int id, PedidoExameRequestDto dto)
        {
            #region Buscar o pedido no banco de dados através do ID

            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                throw new ApplicationException("Pedido de Exame não encontrado, verifique o ID informado.");

            #endregion

            #region Atribuir os dados do pedido

            pedido.PacienteId  = dto.PacienteId;
            pedido.ExameId     = dto.ExameId;
            pedido.DataPedido  = dto.DataPedido;
            pedido.Observacoes = dto.Observacoes;
            pedido.MedicoSolicitante  = dto.MedicoSolicitante;
            pedido.SituacaoPedidoExame = (int?)dto.SituacaoPedidoExame;

            #endregion

            #region Realizar o atualização do pedido

            await _pedidoRepository.UpdateAsync(pedido);

            return new PedidoExameResponseDto
            {
                Id = pedido.Id,
                PacienteId  = pedido.PacienteId,
                ExameId     = pedido.ExameId,
                DataPedido  = pedido.DataPedido,
                Observacoes = pedido.Observacoes,
                MedicoSolicitante = pedido.MedicoSolicitante,
                SituacaoPedidoExame = (int?)dto.SituacaoPedidoExame,
            };

            #endregion
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            #region Buscar o pedido no banco de dados através do ID

            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                throw new ApplicationException("PedidoExame não encontrado, verifique o ID informado.");

            #endregion

            await _pedidoRepository.DeleteAsync(id);
            return true; 
        }

        public async Task<List<PedidoExameResponseDto>> ConsultarAsync()
        {
            var response = new List<PedidoExameResponseDto>();
            var pedidos = await _pedidoRepository.GetAllAsync();

            foreach (var item in pedidos)
            {
                response.Add(new PedidoExameResponseDto
                {
                    Id = item.Id,

                    PacienteId  = item.PacienteId,
                    ExameId     = item.ExameId,
                    DataPedido  = item.DataPedido,
                    Observacoes = item.Observacoes,
                    MedicoSolicitante = item.MedicoSolicitante,
                    SituacaoPedidoExame = (int?)item.SituacaoPedidoExame,
                });
            }

            return response;
        }

        public async Task<PedidoExameResponseDto> ObterPorIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                throw new ApplicationException("PedidoExame não encontrado, verifique o ID informado.");

            return new PedidoExameResponseDto
            {
                PacienteId  = pedido.PacienteId,
                ExameId     = pedido.ExameId,
                DataPedido  = pedido.DataPedido,
                Observacoes = pedido.Observacoes,
                MedicoSolicitante = pedido.MedicoSolicitante,
                SituacaoPedidoExame = (int?)pedido.SituacaoPedidoExame,
            };
        }

    }
}