using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly ProductRepository _contextProduct;
        private readonly OrderDetailRepository _context;
        private readonly OrderRepository _contextOrder;

        public OrderDetailsController(OrderDetailRepository context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public IActionResult Index()
        {
            var orderDetails = _context.GetAll();
            return View(orderDetails);
        }

        // GET: OrderDetails/Details/5
        public IActionResult Details(int id)
        {
            var orderDetail = _context.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.GetAll(), "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.GetAll(), "ProductId", "ProductId");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            var orderId = orderDetail.OrderDetailsId;
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.GetAll(), "OrderId", "OrderId", orderId);
            ViewData["ProductId"] = new SelectList(_context.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public IActionResult Edit(int id)
        {
             var orderDetail = _context.GetById(id);

            if (orderDetail == null) return NotFound();

            var order = _contextOrder.GetById(orderDetail.OrderDetailsId);
            var product = _contextProduct.GetById(orderDetail.ProductId);

           // ViewData["OrderId"] = new SelectList(_contextOrder.GetAll(), "OrderId", "OrderId", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_contextProduct.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailsId))
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
            ViewData["OrderId"] = new SelectList(_contextOrder.GetAll(), "OrderId", "OrderId", orderDetail);   
            ViewData["ProductId"] = new SelectList(_contextProduct.GetAll(), "ProductId", "ProductId", orderDetail.ProductId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = _context.GetById(id);
            
            if (_context == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: OrderDetails/Delete/5
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

        private bool OrderDetailExists(int id)
        {
            return _context.GetById(id) != null;
        }
    }
}
