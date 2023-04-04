using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetDayOfTrainByIdQuery : IRequest<DayOfTrain>
    {
        public int Id { get; set; }

        public GetDayOfTrainByIdQuery(int id)
        {
            Id = id;
        }
    }
}
