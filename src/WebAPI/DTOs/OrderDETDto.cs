using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class OrderDETDto
    {
        public string PartNum { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}
