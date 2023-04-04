using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ManagerCreateCommandHandler : IRequestHandler<ManagerCreateCommand, Manager>
    {
        private readonly IManagerRepository _managerRepository;
        public ManagerCreateCommandHandler(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository ?? throw new
                ArgumentNullException(nameof(managerRepository));
        }
        public async Task<Manager> Handle(ManagerCreateCommand request,
            CancellationToken cancellationToken)
        {
            var manager = new Manager(request.User, request.Avaliations, request.Roles, request.ClientWorkouts);
            
            if (manager == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _managerRepository.CreateAsync(manager);
            }
        }
    }
}
