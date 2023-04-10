using SabidoMagroAcademia.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ActivityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Label is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Label")]
        public string Label { get; set; }
    }
}
