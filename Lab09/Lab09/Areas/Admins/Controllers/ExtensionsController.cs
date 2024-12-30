using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab09.Models;
using X.PagedList;

namespace Lab09.Areas.Admins.Controllers
{
    [Area("Admins")]
    public class ExtensionsController : Controller
    {
        private readonly DevXuongMocContext _context;

        public ExtensionsController(DevXuongMocContext context)
        {
            _context = context;
        }

        // GET: Admins/Extensions
        public async Task<IActionResult> Index(string name, int page = 1)
        {
            //số bản ghi trên 1 trang
            int limit = 5;
            var extensions = await _context.Extensions.OrderBy(p => p.Id).ToPagedListAsync(page, limit);
            if (!String.IsNullOrEmpty(name))
            {
                extensions = await _context.Extensions.Where(p => p.Title.Contains(name)).OrderBy(p => p.Id).ToPagedListAsync(page, limit);
            }
            ViewBag.keyword = name;
            return View(extensions);
        }

        // GET: Admins/Extensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extension = await _context.Extensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extension == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", extension);
        }

        // GET: Admins/Extensions/Create
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Admins/Extensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Icon,MetaTitle,MetaKeyword,MetaDescription,Slug,Orders,Parentid,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Notes,Status,Isdelete")] Extension extension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Create", extension);
        }

        // GET: Admins/Extensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extension = await _context.Extensions.FindAsync(id);
            if (extension == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", extension);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Icon,MetaTitle,MetaKeyword,MetaDescription,Slug,Orders,Parentid,CreatedDate,UpdatedDate,AdminCreated,AdminUpdated,Notes,Status,Isdelete")] Extension extension)
        {
            if (id != extension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtensionExists(extension.Id))
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
            return PartialView("_Edit", extension);
        }

        // GET: Admins/Extensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extension = await _context.Extensions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (extension == null)
            {
                return NotFound();
            }

            return PartialView("_Delete", extension);
        }

        // POST: Admins/Extensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var extension = await _context.Extensions.FindAsync(id);
            if (extension != null)
            {
                _context.Extensions.Remove(extension);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtensionExists(int id)
        {
            return _context.Extensions.Any(e => e.Id == id);
        }
    }
}
