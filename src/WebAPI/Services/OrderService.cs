using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Configuration;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        //Business would go here
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> DeleteOrders(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Order> GetOrder(int id)
        {
            //should return domain model object 
            return _unitOfWork.Orders.GetById(id);
        }

        public Task InsertOrders(Order post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrders(Order post)
        {
            throw new NotImplementedException();
        }
    }
}
