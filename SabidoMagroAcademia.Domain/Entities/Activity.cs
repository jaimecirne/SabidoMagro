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

        public Activity(int id, String label)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(label), "Invalid Label value.");

            Id = id;
            Label = label;
        }
    }
}
