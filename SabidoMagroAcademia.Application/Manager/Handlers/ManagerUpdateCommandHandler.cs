using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ManagerUpdateCommandHandler : IRequestHandler<ManagerUpdateCommand, Manager>
    {
        private readonly IManagerRepository _managerRepository;
        public ManagerUpdateCommandHandler(IManagerRepository productRepository)
        {
            _managerRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Manager> Handle(ManagerUpdateCommand request, CancellationToken cancellationToken)
        {
            var manager = await _managerRepository.GetByIdAsync(request.Id);

            if (manager == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                manager.Update(request.User, request.Avaliations, request.DayOfTrains,
                                request.ManagerWorkouts);
                return await _managerRepository.UpdateAsync(manager);
            }

        }
    }
}
