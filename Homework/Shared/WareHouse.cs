﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Capacity { get; set; }
        List<Baraa> Items { get; set; } = new List<Baraa>();
        //public WareHouse(string _name, int _cap)
        //{
        //    Name = _name;
        //    Capacity = _cap;
        //    Items = new List<Baraa>();
        //}
    }
}
