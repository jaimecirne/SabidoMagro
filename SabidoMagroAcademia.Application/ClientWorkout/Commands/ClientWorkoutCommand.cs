using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ClientWorkoutCommand : IRequest<ClientWorkout>
    {
        public Client Client { get; set; }
        public Manager Coach { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Workout> WorkoutDefaults { get; set; }

    }
}
