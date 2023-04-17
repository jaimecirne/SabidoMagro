using SabidoMagroAcademia.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Plan : Entity
    {
        public string Name { get; private set; }
        public float Price { get; set; }

        public Plan()
        {

        }

        public Plan(string name, float price )
        {
            ValidateDomain(name, price);
        }

        public Plan(int id, string name, float price)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, price);
        }

        public void Update(string name, float price)
        {
            ValidateDomain(name, price);
        }
        public ICollection<Client> Clients { get; set; }

        private void ValidateDomain(string name, float price)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(price < 0, "Invalid Price value.");

            Name = name;
            Price = price;
        }
    }
}
