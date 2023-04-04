using AutoMapper;
using MediatR;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Application.Products.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Services
{
    public class ContractService : IContractService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ContractService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ContractDTO>> GetContracts()
        {
            var contractsQuery = new GetContractsQuery();

            if (contractsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(contractsQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ContractDTO>>(result);
        }

        public async Task<ContractDTO> GetById(int? id)
        {
            var contractByIdQuery = new GetContractByIdQuery(id.Value);

            if (contractByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(contractByIdQuery);

            return _mapper.Map<ContractDTO>(result);
        }

        public async Task Add(ContractDTO contractDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var contractCreateCommand = _mapper.Map<ContractCreateCommand>(contractDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(contractCreateCommand);
        }

        public async Task Update(ContractDTO contractDto)
        {
            var contractUpdateCommand = _mapper.Map<ContractUpdateCommand>(contractDto);
            await _mediator.Send(contractUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var contractRemoveCommand = new ContractRemoveCommand(id.Value);
            if (contractRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(contractRemoveCommand);
        }
    }
}
