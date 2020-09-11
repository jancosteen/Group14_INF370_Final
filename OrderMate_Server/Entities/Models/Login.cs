using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Login
    {
        [Required]
    
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
