using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(int id);

        Task InsertOrders(Order post);

        Task<bool> UpdateOrders(Order post);

        Task<bool> DeleteOrders(int id);
    }
}
