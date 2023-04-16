using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        public User User { get; set; }

        [DisplayName("Avaliations")]
        public List<Avaliation> Avaliations { get; set; }
       
        [DisplayName("DayOfTrains")]
        public List<DayOfTrain> DayOfTrains { get; set; }

        [DisplayName("ClientWorkouts")]
        public List<ClientWorkout> ClientWorkouts { get; set; }

    }
}
