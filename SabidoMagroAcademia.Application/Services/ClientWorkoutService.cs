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
    public class ClientWorkoutService : IClientWorkoutService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ClientWorkoutService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ClientWorkoutDTO>> GetClientWorkouts()
        {
            var clientworkoutsQuery = new GetClientWorkoutsQuery();

            if (clientworkoutsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(clientworkoutsQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ClientWorkoutDTO>>(result);
        }

        public async Task<ClientWorkoutDTO> GetById(int? id)
        {
            var clientworkoutByIdQuery = new GetClientWorkoutByIdQuery(id.Value);

            if (clientworkoutByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(clientworkoutByIdQuery);

            return _mapper.Map<ClientWorkoutDTO>(result);
        }

        public async Task Add(ClientWorkoutDTO clientworkoutDto)
        {
            //realiza o mapeamento da classe DTO para classe command
            var clientworkoutCreateCommand = _mapper.Map<ClientWorkoutCreateCommand>(clientworkoutDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(clientworkoutCreateCommand);
        }

        public async Task Update(ClientWorkoutDTO clientworkoutDto)
        {
            var clientworkoutUpdateCommand = _mapper.Map<ClientWorkoutUpdateCommand>(clientworkoutDto);
            await _mediator.Send(clientworkoutUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var clientworkoutRemoveCommand = new ClientWorkoutRemoveCommand(id.Value);
            if (clientworkoutRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(clientworkoutRemoveCommand);
        }
    }
}
