using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class WareProduct : Product
    {
        public int Count { get; set; }
        public int WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
