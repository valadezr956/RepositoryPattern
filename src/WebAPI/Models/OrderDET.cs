using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderDET
    {
        public int Id { get; set; }
        public string PartNum { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

        public virtual int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
