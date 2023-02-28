using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class WareProduct : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public UnitMeas Meas { get; set; }
        public int Count { get; set; }
        public int WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
