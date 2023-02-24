using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared
{
    public class TransactionProd
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public Product? Product { get; set; }
        public int FromWareHouseId { get; set; }
        public int ToWareHouseId { get; set;}
    }
}
