using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientWorkoutCreateCommandHandler : IRequestHandler<ClientWorkoutCreateCommand, ClientWorkout>
    {
        private readonly IClientWorkoutRepository _clientworkoutRepository;
        public ClientWorkoutCreateCommandHandler(IClientWorkoutRepository clientworkoutRepository)
        {
            _clientworkoutRepository = clientworkoutRepository ?? throw new
                ArgumentNullException(nameof(clientworkoutRepository));
        }
        public async Task<ClientWorkout> Handle(ClientWorkoutCreateCommand request,
            CancellationToken cancellationToken)
        {
            var clientworkout = new ClientWorkout(request.User);
            
            if (clientworkout == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _clientworkoutRepository.CreateAsync(clientworkout);
            }
        }
    }
}
