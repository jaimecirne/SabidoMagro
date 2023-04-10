using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The User is Required")]
        [DisplayName("User")]
        public User User { get; set; }

        [Required(ErrorMessage = "The Avaliations is Required")]
        [DisplayName("Avaliations")]
        public List<Avaliation> Avaliations { get; set; }

        [Required(ErrorMessage = "The DayOfTrains is Required")]
        [DisplayName("DayOfTrains")]
        public List<DayOfTrain> DayOfTrains { get; set; }

        [Required(ErrorMessage = "The ClientWorkouts is Required")]
        [DisplayName("ClientWorkouts")]
        public List<ClientWorkout> ClientWorkouts { get; set; }


    }
}
