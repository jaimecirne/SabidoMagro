using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ActivityCommand : IRequest<Activity>
    {
        public string Label { get; set; }

    }
}
