using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    class Contract: Entity
    {
        public Plan Plan { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Boolean Active { get; set; }
    }
}
