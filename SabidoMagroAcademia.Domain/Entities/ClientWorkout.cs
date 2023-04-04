using SabidoMagroAcademia.Domain.Validation;
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

        public ClientWorkout()
        {

        }

        public ClientWorkout(Client client, DateTime start, DateTime end, Manager coach)
        {
            ValidateDomain(client, start, end, coach);
        }

        private void ValidateDomain(Client client, DateTime start, DateTime end, Manager coach)
        {
            /*DomainExceptionValidation.When(string.IsNullOrEmpty(client),
                "Invalid label. Label is required");*/


            Client = client;
            Start = start;
            End = end;
            Coach = coach;
        }

        public void Update(int id, Client client, DateTime start, DateTime end, Manager coach)
        {
            ValidateDomain(client, start, end, coach);
            Id = id;
        }

    }
}
