using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Manager: Entity
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<ClientWorkout> ClientWorkouts { get; set; }

    }
}
