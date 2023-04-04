using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class DayOfTrain : Entity
    {
        public DateTime Day { get; set; }
        public Manager Coach { get; set; }
        public Workout WorkoutInDay { get; set; }
        public Client Client { get; set; }

        public int WorkoutId { get; set; }

        public DayOfTrain()
        {

        }

        public DayOfTrain(Manager coach, Workout workoutInDay, Client client)
        {
            this.ValidateDomain(coach, workoutInDay, client);
        }

        private void ValidateDomain(Manager coach, Workout workoutInDay, Client client)
        {
            Day = DateTime.Now;
            Coach = coach;
            WorkoutInDay = workoutInDay;
            Client = client;
        }

        

        public void Update(int id, Manager coach, Workout workoutInDay, Client client)
        {
            ValidateDomain(coach, workoutInDay, client);
            Id = id;
        }

    }
}
