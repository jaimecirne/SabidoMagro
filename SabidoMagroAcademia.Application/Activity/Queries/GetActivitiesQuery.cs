using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetActivitiesQuery : IRequest<IEnumerable<Activity>>
    {
    }
}