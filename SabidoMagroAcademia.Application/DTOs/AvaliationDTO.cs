using SabidoMagroAcademia.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class AvaliationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Label is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Label")]
        public string Label { get; set; }


        [Required(ErrorMessage = "The Weight is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Peso")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "The Height is Required")]
        [Range(1, 9999)]//define um range, garante que não vai receber 0 ou negativo
        [DisplayName("Altura")]
        public int Height { get; set; }

        [Required(ErrorMessage = "The Coach's Comments are Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("CoachsComments")]
        public string CoachsComments { get; set; }

        [Required(ErrorMessage = "The Date is Required")]
        [DisplayName("Date")]
        public DateTime Date{ get; set; }

        [JsonIgnore]
        public Client Client { get; set; }

        [JsonIgnore]
        public Manager Coach { get; set; }

        [DisplayName("Client")]
        public int ClientId { get; set; }

        [DisplayName("Coach")]
        public int CoachId { get; set; }

    }
}
