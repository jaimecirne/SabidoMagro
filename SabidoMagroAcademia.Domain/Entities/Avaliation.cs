using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    class Avaliation : Entity
    {
        public String Label { get; set; }
        public decimal Weight { get; private set; }
        public int Height { get; private set; }
        public String CoachsComments { get; set; }
        public Manager Coach { get; set; }
        public int IMC { get; set; }
        public DateTime Date { get; set; }


        public Avaliation(String label, decimal weight, int height, String coachsComments, Manager coach, int imc)
        {
            ValidateDomain(label, weight, height, coachsComments, coach, imc);
        }

        private void ValidateDomain(String label, decimal weight, int height, String coachsComments, Manager coach, int imc)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(label),
                "Invalid label. Label is required");

            DomainExceptionValidation.When(label.Length < 3,
                "Invalid label, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(coachsComments),
                "Invalid coachsComments. Description is required");

            DomainExceptionValidation.When(coachsComments.Length < 5,
                "Invalid coachsComments, too short, minimum 5 characters");

            DomainExceptionValidation.When(weight < 0, "Invalid weight value");

            DomainExceptionValidation.When(height < 0, "Invalid height value");

            Label = label;
            Weight = weight;
            Height = height;
            CoachsComments = coachsComments;
            Coach = coach;
            IMC = imc;
            Date = DateTime.Now;
        }

    }
}
