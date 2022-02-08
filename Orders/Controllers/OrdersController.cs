using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orders.Comunication;
using Orders.Models;

namespace Orders.Controllers
{
    [Route("api/OrdersController")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly ContextBase _context;

        public OrdersController(ContextBase context)
        {
            _context = context;
        }

        // GET: Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Index()
        {
            var contextBase = _context.Order.Include(o => o.Customer).Include(o => o.Product);
            return await contextBase.ToListAsync();
        }

        ////GET: getQueue
        [HttpGet]
        [Route("Queue")]
        public async Task<ActionResult> getQueue()
        {
            try
            {
                Receiver receiver = new Receiver();
                Order order = receiver.rec();
                return CreatedAtAction("Create", order);
            }
            catch (Exception e)
            {
                return NoContent();
            }

        }

        //GET: Orders/GetOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                Customer customer = order.Customer;
                _context.Customer.Add(customer);
                _context.SaveChanges();

                //Customer c = _context.Customer.ToList().Last<Customer>();
                //order.CustomerId = c.Id;
                //order.Customer = c;

                _context.Order.Add(order);
                _context.SaveChanges();

                //Order o = _context.Order.Last();

                //foreach (var product in order.Product)
                //{
                //    //product.OrderId = o.Id;
                //    _context.Product.Add(product);

                //}
                new Publish().pubProduct();

                //await _context.SaveChangesAsync();

                return order;
            }
            return NoContent();
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }

            return order;
        }

        // POST: Orders/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}
