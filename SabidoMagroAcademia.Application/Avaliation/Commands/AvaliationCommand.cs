using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class AvaliationCommand : IRequest<Avaliation>
    {
        public Client Client { get; set; }
        public string Label { get; set; }
        public decimal Weight { get; private set; }
        public int Height { get; private set; }
        public string CoachsComments { get; set; }
        public Manager Coach { get; set; }
        public DateTime Date { get; set; }

    }
}
