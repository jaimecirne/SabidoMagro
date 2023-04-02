using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Entities
{
    class Role
    {
        public String Label { get; set; }
        public String Key { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
