using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class DayOfTrainCommand : IRequest<DayOfTrain>
    {
        public DateTime Day { get; set; }
        public Manager Coach { get; set; }
        public Workout WorkoutInDay { get; set; }
        public Client Client { get; set; }
    }
}
