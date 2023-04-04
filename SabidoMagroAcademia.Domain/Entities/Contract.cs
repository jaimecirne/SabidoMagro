using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    public sealed class Contract : Entity
    {
        public Plan Plan { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; }
        public int PlanId { get; set; }

        public Contract()
        {

        }

        public Contract(Plan plan, Client client, double totalPrice, DateTime start, DateTime end, bool active)
        {
            ValidateDomain(plan, client, totalPrice, start, end, active);
        }

        private void ValidateDomain(Plan plan, Client client, double totalPrice, DateTime start, DateTime end, bool active)
        {
            /*DomainExceptionValidation.When(string.IsNullOrEmpty(client),
                "Invalid label. Label is required");*/

            Plan = plan;
            Client = client;
            TotalPrice = totalPrice;
            Start = start;
            End = end;
            Active = active;
        }

        public void Update(int id, Plan plan, Client client, double totalPrice, DateTime start, DateTime end, bool active)
        {
            ValidateDomain(plan, client, totalPrice, start, end, active);
            Id = id;
        }
    }
}
