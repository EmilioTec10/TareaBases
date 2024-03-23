using Microsoft.AspNetCore.Mvc;
using RestTecAPI.Entities;
using System.Collections.Generic;

namespace RestTecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChefController : ControllerBase
    {
        private readonly Chef _chef;

        public ChefController()
        {
            _chef = new Chef();
        }

        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {
            var orders = _chef.see_all_orders();
            return Ok(orders);
        }

        [HttpPost("takeorder")]
        public IActionResult TakeOrder(Order order)
        {
            if (_chef.take_order(order))
                return Ok("Order taken successfully");
            else
                return BadRequest("Order not found or already taken");
        }

        [HttpGet("assignedorders")]
        public IActionResult GetAssignedOrders()
        {
            var assignedOrders = _chef.see_assing_orders();
            return Ok(assignedOrders);
        }

        [HttpPost("reassignorder")]
        public IActionResult ReassignOrder(int index, Chef otherChef)
        {
            if (_chef.reassing_order(index, otherChef))
                return Ok("Order reassigned successfully");
            else
                return BadRequest("Failed to reassign order");
        }
    }
}
