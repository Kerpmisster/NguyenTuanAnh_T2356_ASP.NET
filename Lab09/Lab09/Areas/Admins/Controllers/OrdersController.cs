using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab09.Models;
using X.PagedList;
using Microsoft.EntityFrameworkCore.Query;

namespace Lab09.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class OrdersController : Controller
    {
        private readonly DevXuongMocContext _context;

        public OrdersController(DevXuongMocContext context)
        {
            _context = context;
        }

        // GET: Admins/Orders
        public async Task<IActionResult> Index(string name, int page = 1)
        {
            int limit = 5;
            // Lấy dữ liệu ban đầu từ Orders và bao gồm IdCustomerNavigation
            var devXuongMocContext = _context.Orders.Include(o => o.IdCustomerNavigation);

            // Nếu có từ khóa tìm kiếm, lọc dữ liệu theo tên khách hàng
            if (!string.IsNullOrEmpty(name))
            {
                devXuongMocContext = devXuongMocContext
                    .Where(o => o.IdCustomerNavigation.Name.Contains(name))
                    as IIncludableQueryable<Order, Customer?>;
            }

            // Phân trang dữ liệu
            var pagedOrders = await devXuongMocContext
                .OrderBy(o => o.Id)
                .ToPagedListAsync(page, limit);

            // Gửi từ khóa tìm kiếm qua ViewBag
            ViewBag.keyword = name;

            // Trả về view với dữ liệu phân trang
            return View(pagedOrders);
        }

        // GET: Admins/Orders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.IdCustomerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", order);
        }

        // GET: Admins/Orders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id", order.IdCustomer);
            return PartialView("_Edit", order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,IdOrders,IdCustomer,IdPayment,OrdersDate,TotalMoney,Notes,NameReciver,Address,Email,Phone,Isdelete,Isactive")] Order order)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "Id", "Id", order.IdCustomer);
            return PartialView("_Edit", order);
        }

        // GET: Admins/Orders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.IdCustomerNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", order);
        }

        // POST: Admins/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
