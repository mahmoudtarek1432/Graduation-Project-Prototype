using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.data;
using Prototype.Model;

namespace Prototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly Context _ctx;

        public OrderController(Context ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("")]
        public async Task<ActionResult> MakeOrder([FromBody] Order order)
        {
            order.Date = DateTime.Now.ToString();
            order.Orderitems = new List<OrderItems>();
            var orderItems = new List<OrderItems>();
            order.items.ForEach(e =>
            {
                orderItems.Add(new OrderItems { OrderId = 0, MenuItemId = e.Id });
                //order.Orderitems.Add(orderitem);
            });

            order.items = null;
            var key = (await _ctx.Order.AddAsync(order)).Entity.Id;

            orderItems.ForEach(e => e.OrderId = key);
            _ctx.OrderItems.AddRange(orderItems);
            var set = _ctx.Settings.LastOrDefault();
            set.OrderUpdated = true;
            _ctx.Settings.Update(set);
            var temp = _ctx.SaveChanges();
            return Ok();
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Order>> getOrders()
        {
            var orders = _ctx.Order.ToList();
            orders.ForEach(e => { e.Orderitems = new List<OrderItems>(); e.items = new List<MenuItem>(); });
            orders.ForEach(e => {_ctx.OrderItems.Where(OI => OI.OrderId == e.Id).ToList().ForEach(OII =>e.items.Add(_ctx.MenuItems.Where(I => I.Id == OII.MenuItemId).FirstOrDefault()));});

            var set = _ctx.Settings.LastOrDefault();
            set.OrderUpdated = false;
            _ctx.Settings.Update(set);
            _ctx.SaveChanges();
            return Ok(orders);
        }

        [HttpDelete("{Id}")]
        public ActionResult deleteOrder(int Id)
        {
            var deletedOrder = _ctx.Order.Where(e => e.Id == Id).FirstOrDefault();
            deletedOrder.items = null;
            deletedOrder.Orderitems = null;
            _ctx.Order.Remove(deletedOrder);
            _ctx.SaveChanges();
            return Ok();
        }
    }
}