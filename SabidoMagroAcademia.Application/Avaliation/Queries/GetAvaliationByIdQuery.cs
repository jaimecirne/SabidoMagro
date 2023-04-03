using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetAvaliationByIdQuery : IRequest<Avaliation>
    {
        public int Id { get; set; }

        public GetAvaliationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
