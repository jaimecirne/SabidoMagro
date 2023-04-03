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
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public RoleService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var rolesQuery = new GetRolesQuery();

            if (rolesQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(rolesQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<RoleDTO>>(result);
        }

        public async Task<RoleDTO> GetById(int? id)
        {
            var roleByIdQuery = new GetRoleByIdQuery(id.Value);

            if (roleByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(roleByIdQuery);

            return _mapper.Map<RoleDTO>(result);
        }

        public async Task Add(RoleDTO roleDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var roleCreateCommand = _mapper.Map<RoleCreateCommand>(roleDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(roleCreateCommand);
        }

        public async Task Update(RoleDTO roleDto)
        {
            var roleUpdateCommand = _mapper.Map<RoleUpdateCommand>(roleDto);
            await _mediator.Send(roleUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var roleRemoveCommand = new RoleRemoveCommand(id.Value);
            if (roleRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(roleRemoveCommand);
        }
    }
}
