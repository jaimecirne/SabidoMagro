using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleUpdateCommandHandler(IRoleRepository productRepository)
        {
            _roleRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Role> Handle(RoleUpdateCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.Id);

            if (role == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                role.Update(request.User, request.Avaliations, request.DayOfTrains,
                                request.RoleWorkouts);
                return await _roleRepository.UpdateAsync(role);
            }

        }
    }
}
