using MediatR;
using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ResourceCommand : IRequest<Resource>
    {
        public string Label { get; set; }
        public string Key { get; set; }

    }
}
