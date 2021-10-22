using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string SalesOrderID { get; set; }
        public string Invoice { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<OrderDET> Details { get; set; } = new List<OrderDET>();
    }
}
