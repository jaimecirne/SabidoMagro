using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class DayOfTrainUpdateCommandHandler : IRequestHandler<DayOfTrainUpdateCommand, DayOfTrain>
    {
        private readonly IDayOfTrainRepository _dayoftrainRepository;
        public DayOfTrainUpdateCommandHandler(IDayOfTrainRepository productRepository)
        {
            _dayoftrainRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<DayOfTrain> Handle(DayOfTrainUpdateCommand request, CancellationToken cancellationToken)
        {
            var dayoftrain = await _dayoftrainRepository.GetByIdAsync(request.Id);

            if (dayoftrain == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                dayoftrain.Update(request.User, request.Avaliations, request.DayOfTrains,
                                request.DayOfTrainWorkouts);
                return await _dayoftrainRepository.UpdateAsync(dayoftrain);
            }

        }
    }
}
