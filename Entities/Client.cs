﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : BaseModel
    {
        [Required]
        public string Name  { get; set; }

        [Required]
        public string DNI { get; set; }
    }
}
