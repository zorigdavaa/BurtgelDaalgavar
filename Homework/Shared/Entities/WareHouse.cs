using Homework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Product> Items { get; set; } = new List<Product>();
        //public WareHouse(string _name, int _cap)
        //{
        //    Name = _name;
        //    Capacity = _cap;
        //    Items = new List<Baraa>();
        //}
    }
}
