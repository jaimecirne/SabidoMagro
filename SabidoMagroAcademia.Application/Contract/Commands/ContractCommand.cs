using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ContractCommand : IRequest<Contract>
    {
        public Plan Plan { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Active { get; set; }
        public int PlanId { get; set; }

    }
}
