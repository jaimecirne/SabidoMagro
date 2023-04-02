using SabidoMagroAcademia.Domain.Validation;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Client : Entity
    {
        public User User { get; set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<DayOfTrain> DayOfTrains { get; set; }
        public List<ClientWorkout> ClientWorkouts { get; set; }

        public Client()
        {

        }

        public Client(User user)
        {
            ValidateDomain(user);
        }

        public Client(User user, List<Avaliation> avaliations, List<DayOfTrain> dayOfTrains, List<ClientWorkout> clientWorkouts)
        {
            ValidateDomain(user);
            Avaliations = avaliations;
            DayOfTrains = dayOfTrains;
            ClientWorkouts = clientWorkouts;
        }

        public void Update(User user, List<Avaliation> avaliations, List<DayOfTrain> dayOfTrains, List<ClientWorkout> clientWorkouts)
        {
            ValidateDomain(user);
            Avaliations = avaliations;
            DayOfTrains = dayOfTrains;
            ClientWorkouts = clientWorkouts;
        }

        private void ValidateDomain(User user)
        {
            User = user;
        }

    }
}
