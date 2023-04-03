using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class AvaliationCreateCommandHandler : IRequestHandler<AvaliationCreateCommand, Avaliation>
    {
        private readonly IAvaliationRepository _avaliationRepository;
        public AvaliationCreateCommandHandler(IAvaliationRepository avaliationRepository)
        {
            _avaliationRepository = avaliationRepository ?? throw new
                ArgumentNullException(nameof(avaliationRepository));
        }
        public async Task<Avaliation> Handle(AvaliationCreateCommand request,
            CancellationToken cancellationToken)
        {
            var avaliation = new Avaliation(request.User);
            
            if (avaliation == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _avaliationRepository.CreateAsync(avaliation);
            }
        }
    }
}
