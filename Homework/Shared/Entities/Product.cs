using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double SellPrice => Price * 1.5;
        public UnitMeas Meas { get; set; }
        public int Count { get; set; }
        public int? WareHouseId { get; set; }
        public WareHouse? WareHouse { get; set; }
    }
    public enum UnitMeas
    {
        Undefined, KG, Litr, Unit, Gallon, Boodol, Box
    }
}
