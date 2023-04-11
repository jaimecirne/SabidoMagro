using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class WorkoutActivity: Entity
    {
        public int Order { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Rest { get; set; }
        public Workout Workout { get; set; }
        public Activity Activity { get; set; }

        public int WorkoutId { get; set; }
        public int ActivityId { get; set; }

        public WorkoutActivity(int id, int order , int sets, int reps, int rest, int activityId, int workoutId)
        {
            Order = order;
            Sets = sets;
            Reps = reps;
            Rest = rest;
            ActivityId = activityId;
            WorkoutId = workoutId;
            Id = id;
        }

        public WorkoutActivity()
        {

        }
    }
}
