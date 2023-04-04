using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetActivitiesByIdQuery : IRequest<Activity>
    {
        public int Id { get; set; }

        public GetActivitiesByIdQuery(int id)
        {
            Id = id;
        }
    }
}
