using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class ClientWorkout: Entity
    {
        public Client Client { get; set; }
        public Manager Coach { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Workout> WorkoutDefaults { get; set; }

        public int ClientId { get; set; }
    }
}
