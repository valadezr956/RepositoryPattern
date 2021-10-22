using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repos.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Order GetRecentOrder();
    }
}
