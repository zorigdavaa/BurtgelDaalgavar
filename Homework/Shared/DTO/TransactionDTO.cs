using Homework.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public int FromWareHouseId { get; set; }
        public int ToWareHouseId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public UnitMeas ProdMeas { get; set; }
        public int ProductCount { get; set; }

    }
}
