using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Baraa
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public UnitMeas Meas { get; set; }

    }
    public enum UnitMeas
    {
        Undefined, KG, Litr, Unit, Gallon, Boodol, Box
    }
}
