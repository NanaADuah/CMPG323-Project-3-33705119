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
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _context;

        public CustomersController(SuperStoreContext context)
        {
          //  _context = context;
            _context = new CustomerRepository(context);
        }

        // GET: Customers
        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        // GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.GetById(id);
            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _context.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var customer = _context.GetById(id);
                
            if (customer == null) return NotFound();

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.GetById(id);

            if (customer != null)
                _context.RemoveCustomer(customer);
            
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.GetById(id) != null;
        }
    }
}
