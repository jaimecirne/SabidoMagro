using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, Client>
    {
        private readonly IClientRepository _clientRepository;
        public ClientCreateCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new
                ArgumentNullException(nameof(clientRepository));
        }
        public async Task<Client> Handle(ClientCreateCommand request,
            CancellationToken cancellationToken)
        {
            var client = new Client(request.User);
            
            if (client == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _clientRepository.CreateAsync(client);
            }
        }
    }
}
