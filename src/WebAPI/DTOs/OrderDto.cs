using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class OrderDto
    {
        public string SalesOrderID { get; set; }
        public string Invoice { get; set; }
        public double Total { get; set; }

        public virtual ICollection<OrderDETDto> Details { get; set; } = new List<OrderDETDto>();
    }
}
