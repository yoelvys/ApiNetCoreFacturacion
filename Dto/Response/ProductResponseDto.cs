using System;

namespace Dto.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubProduct { get; set; }
        public double UnitPrice { get; set; }
    }
}
