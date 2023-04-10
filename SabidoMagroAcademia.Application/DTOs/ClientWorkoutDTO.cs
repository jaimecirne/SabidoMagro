using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ClientWorkoutDTO
    {
        public int Id { get; set; }

        public Client Client { get; set; }
        public Manager Coach { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Workout> WorkoutDefaults { get; set; }

        public int ClientId { get; set; }
    }
}
