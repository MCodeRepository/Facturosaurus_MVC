using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturosaurus.Domain.Entities
{
    public class UnitType
    {
        public int Id { get; set; }
        public string ShortName { get; set; } = "";
        public string FullName { get; set; } = "";
    }
}
