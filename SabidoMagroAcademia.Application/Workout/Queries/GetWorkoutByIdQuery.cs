using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetWorkoutByIdQuery : IRequest<Workout>
    {
        public int Id { get; set; }

        public GetWorkoutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
