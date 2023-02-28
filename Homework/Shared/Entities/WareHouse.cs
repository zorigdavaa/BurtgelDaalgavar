using Homework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class WareHouse : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public List<WareProduct> Items { get; set; } = new List<WareProduct>();
    }
}
