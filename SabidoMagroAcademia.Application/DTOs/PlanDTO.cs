using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SabidoMagroAcademia.Application.DTOs
{
    public class PlanDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
