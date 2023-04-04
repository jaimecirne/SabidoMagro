using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Queries
{
    public class GetClientWorkoutByIdQuery : IRequest<ClientWorkout>
    {
        public int Id { get; set; }

        public GetClientWorkoutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
