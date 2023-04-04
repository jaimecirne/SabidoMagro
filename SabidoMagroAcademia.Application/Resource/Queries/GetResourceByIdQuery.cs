using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetResourceByIdQuery : IRequest<Resource>
    {
        public int Id { get; set; }

        public GetResourceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
