using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class DayOfTrainCreateCommandHandler : IRequestHandler<DayOfTrainCreateCommand, DayOfTrain>
    {
        private readonly IDayOfTrainRepository _dayoftrainRepository;
        public DayOfTrainCreateCommandHandler(IDayOfTrainRepository dayoftrainRepository)
        {
            _dayoftrainRepository = dayoftrainRepository ?? throw new
                ArgumentNullException(nameof(dayoftrainRepository));
        }
        public async Task<DayOfTrain> Handle(DayOfTrainCreateCommand request,
            CancellationToken cancellationToken)
        {
            var dayoftrain = new DayOfTrain(request.Coach, request.WorkoutInDay, request.Client);
            
            if (dayoftrain == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _dayoftrainRepository.CreateAsync(dayoftrain);
            }
        }
    }
}
