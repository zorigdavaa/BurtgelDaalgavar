using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class TransactionProd : BaseEntity
    {
        public DateTime TransactionDate { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; } = String.Empty;
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }
        public UnitMeas ProductMeas { get; set; }
        public int FromWareHouseId { get; set; }
        public int ToWareHouseId { get; set; }
        public double GetExpenses()
        {
            return ProductPrice * ProductCount;
        }
    }
}
