using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SubProduct { get; set; }

        [Required]
        public double UnitPrice { get; set; }
    }
}
