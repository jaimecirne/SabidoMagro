using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class RoleCommand : IRequest<Role>
    {
        public User User { get; private set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<DayOfTrain> DayOfTrains { get; set; }
        public List<RoleWorkout> RoleWorkouts { get; set; }

    }
}
