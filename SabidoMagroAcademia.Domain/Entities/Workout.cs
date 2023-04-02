using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    class Workout : Entity
    {
        public String Label { get; set; }
        public List<WorkoutActivity> WorkoutActivities { get; set; }

    }
}
