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

        //[Required(ErrorMessage = "The User is Required")]
        [DisplayName("User")]
        public User User { get; set; }

        //[Required(ErrorMessage = "The Avaliations is Required")]
        [DisplayName("Avaliations")]
        public List<Avaliation> Avaliations { get; set; }

        //[Required(ErrorMessage = "The DayOfTrains is Required")]
        [DisplayName("DayOfTrains")]
        public List<DayOfTrain> DayOfTrains { get; set; }

        //[Required(ErrorMessage = "The ClientWorkouts is Required")]
        [DisplayName("ClientWorkouts")]
        public List<ClientWorkout> ClientWorkouts { get; set; }


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

        [DisplayName("Imagem")]
        public string Image { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }
        public string Fone { get; set; }

        public string Gender;

        public DateTime Born;


    }
}
