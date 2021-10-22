using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repos.IRepositories;

namespace WebAPI.Repos.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override Task<Order> GetById(int id)
        {
            return Task.FromResult(dbSet.Include(x => x.Details).Where(x => x.Id == id).First());
        }
        public Order GetRecentOrder()
        {
            return dbSet.OrderBy(x => x.Date).First();
        }
    }
}
