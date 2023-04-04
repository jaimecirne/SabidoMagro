using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public class Activity : Entity
    {
        public string Label { get; set; }

        public Activity()
        {

        }

        public Activity(int id, string label)
        {
            ValidateDomain(label);
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");

            Id = id;
        }

        public Activity(String label)
        {
            ValidateDomain(label);
        }

        private void ValidateDomain(String label) {
            DomainExceptionValidation.When(string.IsNullOrEmpty(label), "Invalid Label value.");
            Label = label;
        }

        public void Update(int id, String label)
        {
            ValidateDomain(label);
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");

            Id = id;
        }

    }
}
