using SabidoMagroAcademia.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class DayOfTrainDTO
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }
        public Manager Coach { get; set; }
        public Workout WorkoutInDay { get; set; }
        public Client Client { get; set; }

        public int WorkoutId { get; set; }
    }
}
