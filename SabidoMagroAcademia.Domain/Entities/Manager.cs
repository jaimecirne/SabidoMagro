using System.Collections.Generic;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Manager: Entity
    {
        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<ClientWorkout> ClientWorkouts { get; set; }

        public Manager()
        {

        }

        public Manager(User user, List<Avaliation> avaliations, List<Role> roles, List<ClientWorkout> clientWorkouts)
        {
            ValidateDomain(user, avaliations, roles, clientWorkouts);
        }
        public void Update(int id, User user, List<Avaliation> avaliations, List<Role> roles, List<ClientWorkout> clientWorkouts)
        {
            ValidateDomain(user, avaliations, roles, clientWorkouts);
            
            Id = id;
        }

        private void ValidateDomain(User user, List<Avaliation> avaliations, List<Role> roles, List<ClientWorkout> clientWorkouts)
        {
            User = user;
            Avaliations = avaliations;
            Roles = roles;
            ClientWorkouts = clientWorkouts;
        }

    }
}
