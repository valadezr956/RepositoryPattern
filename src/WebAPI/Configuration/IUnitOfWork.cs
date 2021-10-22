using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repos.IRepositories;

namespace WebAPI.Configuration
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        Task SaveChangesAsync();
    }
}
