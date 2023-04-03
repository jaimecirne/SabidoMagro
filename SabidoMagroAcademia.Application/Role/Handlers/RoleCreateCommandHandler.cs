using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleCreateCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository ?? throw new
                ArgumentNullException(nameof(roleRepository));
        }
        public async Task<Role> Handle(RoleCreateCommand request,
            CancellationToken cancellationToken)
        {
            var role = new Role(request.User);
            
            if (role == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _roleRepository.CreateAsync(role);
            }
        }
    }
}
