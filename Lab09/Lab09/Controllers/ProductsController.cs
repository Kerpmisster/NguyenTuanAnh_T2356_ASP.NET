using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab09.Models;

namespace Lab09.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ProductsController(DevXuongMocContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                  .Include(c => c.Products) // Bao gồm danh sách sản phẩm
/*                  .Where(c => c.Products.Any() && c.Status == 1 && c.Isdelete == false)*/ // Lọc danh mục có ít nhất 1 sản phẩm
                  .ToListAsync();

            return View(categories);
            //return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Category/5
        //public async Task<IActionResult> Category(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = await _context.Categories
        //        .Include(c => c.Products)
        //        .FirstOrDefaultAsync(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(category.Products);
        //}

    }
}
