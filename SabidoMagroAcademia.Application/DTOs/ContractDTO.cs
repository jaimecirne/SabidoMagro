using SabidoMagroAcademia.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ContractDTO
    {
        public int Id { get; set; }

        public Plan Plan { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; }
        public int PlanId { get; set; }

    }
}
