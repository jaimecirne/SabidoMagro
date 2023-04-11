using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class WorkoutCommand : IRequest<Workout>
    {
        public string Label { get; set; }

        public List<WorkoutActivity> WorkoutActivities { get; set; }


    }
}
