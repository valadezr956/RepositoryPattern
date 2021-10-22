using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Configuration;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderService _service;

        public OrdersController(ILogger<OrdersController> logger, IUnitOfWork unitOfWork, IMapper mapper, IOrderService service)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _unitOfWork.Orders.Add(order);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { order.Id }, order);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
        public async Task<IActionResult> GetItem(int id)
        {
            //var order = await _unitOfWork.Orders.GetById(id);
            var order = await _service.GetOrder(id);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);

            if (orderDto == null)
                return NotFound(); // 404 http status code

            return Ok(orderDto);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Orders.GetAll();

            return Ok(users);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateItem(Order order)
        {
            await _unitOfWork.Orders.Update(order);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _unitOfWork.Orders.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Orders.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return Ok(item);
        }
    }
}
