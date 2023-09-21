using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        //private readonly SuperStoreContext ;
        private readonly OrderRepository _context;// _orderRepository;
        private readonly CustomerRepository _contextCustomer;// _orderRepository;

        public OrdersController(SuperStoreContext context)
        {
            _context = new OrderRepository(context);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = _context.GetAll();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = _context.GetById(id);

            if (_context.GetAll() == null)
            {
                return NotFound();
            }

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_contextCustomer.GetAll(), "CustomerId", "CustomerId");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] OrderDetail order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _context.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.GetAll(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] OrderDetail updateOrder)
        {
            if (id != updateOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateOrder);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(updateOrder.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_contextCustomer.GetAll(), "CustomerId", "CustomerId", updateOrder.CustomerId);
            return View(updateOrder);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int id)
        {
            var order = _context.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            _context.Remove(order);

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _context.GetById(id);

            if (order != null)
            {
                _context.Remove(order);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.GetById(id) != null;
        }
    }
}
