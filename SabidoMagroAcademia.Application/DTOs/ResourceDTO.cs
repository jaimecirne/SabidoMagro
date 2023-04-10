using SabidoMagroAcademia.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class ResourceDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Label is Required")]
        [MinLength(3)]
        [MaxLength(200)]
        [DisplayName("Label")]
        public string Label { get; set; }

        [Required(ErrorMessage = "The key is Required")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Key")]
        public string Key { get; set; }

    }
}
