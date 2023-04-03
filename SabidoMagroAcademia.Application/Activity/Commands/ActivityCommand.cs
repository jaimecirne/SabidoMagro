using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ActivityCommand : IRequest<Activity>
    {
        public User User { get; private set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<DayOfTrain> DayOfTrains { get; set; }
        public List<ActivityWorkout> ActivityWorkouts { get; set; }

    }
}
