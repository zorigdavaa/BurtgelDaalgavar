using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Shared.Entities
{
    public class Userr : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
