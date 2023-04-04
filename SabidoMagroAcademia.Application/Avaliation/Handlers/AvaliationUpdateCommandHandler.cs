using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class AvaliationUpdateCommandHandler : IRequestHandler<AvaliationUpdateCommand, Avaliation>
    {
        private readonly IAvaliationRepository _avaliationRepository;
        public AvaliationUpdateCommandHandler(IAvaliationRepository productRepository)
        {
            _avaliationRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Avaliation> Handle(AvaliationUpdateCommand request, CancellationToken cancellationToken)
        {
            var avaliation = await _avaliationRepository.GetByIdAsync(request.Id);

            if (avaliation == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                avaliation.Update(request.User, request.Avaliations, request.DayOfTrains,
                                request.AvaliationWorkouts);
                return await _avaliationRepository.UpdateAsync(avaliation);
            }

        }
    }
}
