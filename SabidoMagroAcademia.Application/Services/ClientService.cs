using AutoMapper;
using MediatR;
using SabidoMagroAcademia.Application.DTOs;
using SabidoMagroAcademia.Application.Interfaces;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;//utiliza essa instância para enviar os requests para os handles
        public ClientService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ClientDTO>> GetClients()
        {
            var clientsQuery = new GetClientsQuery();

            if (clientsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            //envia-se o tipo de handler através do .Send para ser executado
            var result = await _mediator.Send(clientsQuery);

            //necessário mapear o retorno para DTO
            return _mapper.Map<IEnumerable<ClientDTO>>(result);
        }

        public async Task<ClientDTO> GetById(int? id)
        {
            var clientByIdQuery = new GetClientByIdQuery(id.Value);

            if (clientByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(clientByIdQuery);

            return _mapper.Map<ClientDTO>(result);
        }

        public async Task Add(ClientDTO clientDto)
        {
            //List<Avaliation> avaliations = new List<Avaliation>();
            //avaliations.Add(new Avaliation(clientDto.Weight, clientDto.Height));

            //ClientDTO client = new ClientDTO
            //{
            //    User = new User
            //    (
            //        clientDto.Name,
            //        clientDto.Email,
            //        "0000-0000",
            //        "Masculino",//clientDto.Gender,
            //        DateTime.Now,//clientDto.Born,
            //        clientDto.Image
            //     ),
            //    Avaliations = avaliations,
            //    DayOfTrains = new List<DayOfTrain>(),
            //    ClientWorkouts = new List<ClientWorkout>()
            //};
            //realiza o mapeamento da classe DTO para classe command
            var clientCreateCommand = _mapper.Map<ClientCreateCommand>(clientDto);
            //através do tipo de classe command informada o mediator sabe qual handler chamar
            await _mediator.Send(clientCreateCommand);
        }

        public async Task Update(ClientDTO clientDto)
        {
            var clientUpdateCommand = _mapper.Map<ClientUpdateCommand>(clientDto);
            await _mediator.Send(clientUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var clientRemoveCommand = new ClientRemoveCommand(id.Value);
            if (clientRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(clientRemoveCommand);
        }
    }
}
