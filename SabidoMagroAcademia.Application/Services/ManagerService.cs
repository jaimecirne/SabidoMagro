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
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ManagerService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ManagerDTO>> GetManagers()
        {
            var managersQuery = new GetManagersQuery();

            if (managersQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(managersQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ManagerDTO>>(result);
        }

        public async Task<ManagerDTO> GetById(int? id)
        {
            var managerByIdQuery = new GetManagerByIdQuery(id.Value);

            if (managerByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(managerByIdQuery);

            return _mapper.Map<ManagerDTO>(result);
        }

        public async Task Add(ManagerDTO managerDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var managerCreateCommand = _mapper.Map<ManagerCreateCommand>(managerDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(managerCreateCommand);
        }

        public async Task Update(ManagerDTO managerDto)
        {
            var managerUpdateCommand = _mapper.Map<ManagerUpdateCommand>(managerDto);
            await _mediator.Send(managerUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var managerRemoveCommand = new ManagerRemoveCommand(id.Value);
            if (managerRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(managerRemoveCommand);
        }
    }
}
