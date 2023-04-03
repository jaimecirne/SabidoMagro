using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetManagerByIdQuery : IRequest<Manager>
    {
        public int Id { get; set; }

        public GetManagerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
