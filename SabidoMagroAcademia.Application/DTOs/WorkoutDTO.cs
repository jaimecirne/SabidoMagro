using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class WorkoutDTO
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public List<WorkoutActivity> WorkoutActivities { get; set; }
    }
}
