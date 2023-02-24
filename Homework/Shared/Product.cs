using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; }
        public UnitMeas Meas { get; set; }
        public int Count;
    }
    public enum UnitMeas
    {
        Undefined, KG, Litr, Unit, Gallon, Boodol, Box
    }
}
