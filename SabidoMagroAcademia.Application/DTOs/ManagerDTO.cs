using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ManagerDTO
    {
        public int Id { get; set; }

        public User User { get; set; }
        public List<Role> Roles { get; set; }
        public List<Avaliation> Avaliations { get; set; }
        public List<ClientWorkout> ClientWorkouts { get; set; }

    }
}
