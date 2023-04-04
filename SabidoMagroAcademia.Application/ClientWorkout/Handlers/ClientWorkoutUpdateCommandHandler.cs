using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientWorkoutUpdateCommandHandler : IRequestHandler<ClientWorkoutUpdateCommand, ClientWorkout>
    {
        private readonly IClientWorkoutRepository _clientworkoutRepository;
        public ClientWorkoutUpdateCommandHandler(IClientWorkoutRepository productRepository)
        {
            _clientworkoutRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<ClientWorkout> Handle(ClientWorkoutUpdateCommand request, CancellationToken cancellationToken)
        {
            var clientworkout = await _clientworkoutRepository.GetByIdAsync(request.Id);

            if (clientworkout == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                clientworkout.Update(request.Id, request.Client, request.Start, request.End, request.Coach);
                return await _clientworkoutRepository.UpdateAsync(clientworkout);
            }

        }
    }
}
