using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class Product : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public UnitMeas Meas { get; set; }
    }
    public enum UnitMeas
    {
        Undefined, KG, Litr, Unit, Gallon, Boodol, Box
    }
}
