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
    public class ActivityService : IActivityService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ActivityService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ActivityDTO>> GetActivities()
        {
            var activitysQuery = new GetActivitiesQuery();

            if (activitysQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(activitysQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ActivityDTO>>(result);
        }

        public async Task<ActivityDTO> GetById(int? id)
        {
            var activityByIdQuery = new GetActivitiesByIdQuery(id.Value);

            if (activityByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(activityByIdQuery);

            return _mapper.Map<ActivityDTO>(result);
        }

        public async Task Add(ActivityDTO activityDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var activityCreateCommand = _mapper.Map<ActivityCreateCommand>(activityDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(activityCreateCommand);
        }

        public async Task Update(ActivityDTO activityDto)
        {
            var activityUpdateCommand = _mapper.Map<ActivityUpdateCommand>(activityDto);
            await _mediator.Send(activityUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var activityRemoveCommand = new ActivityRemoveCommand(id.Value);
            if (activityRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(activityRemoveCommand);
        }
    }
}
