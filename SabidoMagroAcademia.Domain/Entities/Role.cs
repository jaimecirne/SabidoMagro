using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Role: Entity
    {
        public string Label { get; set; }
        public string Key { get; set; }
        public List<Resource> Resources { get; set; }

        public Role()
        {

        }

        public Role(string label, string key)
        {            
            ValidateDomain(label, key);
        }

        public void Update(int id, string label, string key)
        {
            ValidateDomain(label, key);
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
        }
        public ICollection<Client> Clients { get; set; }

        private void ValidateDomain(string label, string key)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(label),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(label.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(key),
                 "Invalid name.Name is required");

            DomainExceptionValidation.When(key.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            Label = label;
            Key = key;
        }

    }
}
