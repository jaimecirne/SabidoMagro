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
    public class ResourceService : IResourceService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ResourceService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ResourceDTO>> GetResources()
        {
            var resourcesQuery = new GetResourcesQuery();

            if (resourcesQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(resourcesQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ResourceDTO>>(result);
        }

        public async Task<ResourceDTO> GetById(int? id)
        {
            var resourceByIdQuery = new GetResourceByIdQuery(id.Value);

            if (resourceByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(resourceByIdQuery);

            return _mapper.Map<ResourceDTO>(result);
        }

        public async Task Add(ResourceDTO resourceDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var resourceCreateCommand = _mapper.Map<ResourceCreateCommand>(resourceDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(resourceCreateCommand);
        }

        public async Task Update(ResourceDTO resourceDto)
        {
            var resourceUpdateCommand = _mapper.Map<ResourceUpdateCommand>(resourceDto);
            await _mediator.Send(resourceUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var resourceRemoveCommand = new ResourceRemoveCommand(id.Value);
            if (resourceRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(resourceRemoveCommand);
        }
    }
}
