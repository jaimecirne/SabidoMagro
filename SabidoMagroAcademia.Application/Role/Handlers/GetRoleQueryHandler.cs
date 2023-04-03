using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetRoleQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<Role>>
    {

        private readonly IRoleRepository _productRepository;

        public GetRoleQueryHandler(IRoleRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetRolesAsync();
        }

    }
}
