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
        public DateTime TransactionDate { get; set; }
        public Product Product { get; set; } = new Product();
        public int FromWareHouseId { get; set; }
        public int ToWareHouseId { get; set; }
        public double GetExpenses()
        {
            return Product.Price * Product.Count;
        }
    }
}
