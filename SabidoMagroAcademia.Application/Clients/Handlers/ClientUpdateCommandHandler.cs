using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, Client>
    {
        private readonly IClientRepository _clientRepository;
        public ClientUpdateCommandHandler(IClientRepository productRepository)
        {
            _clientRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Client> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);

            if (client == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                client.Update(request.User, request.Avaliations, request.DayOfTrains,
                                request.ClientWorkouts);
                return await _clientRepository.UpdateAsync(client);
            }

        }
    }
}
