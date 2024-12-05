using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class DesignerController : Controller
    {
        private readonly ProductContext _context;

        public DesignerController(ProductContext context)
        {
            _context = context;
        }

        // GET: Designer
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var designers = from d in _context.Designers
                            select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                designers = designers.Where(d => d.LastName.Contains(searchString) || d.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    designers = designers.OrderByDescending(d => d.LastName);
                    break;
                default:
                    designers = designers.OrderBy(d => d.LastName);
                    break;
            }

            int pageSize = 4;
            return View(await PaginatedList<Designer>.CreateAsync(designers.AsNoTracking(), pageNumber ?? 1, pageSize));

              /*return _context.Designers != null ? 
                          View(await _context.Designers.ToListAsync()) :
                          Problem("Entity set 'ProductContext.Designers'  is null.");*/
        }

        // GET: Designer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Designers == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers
                .FirstOrDefaultAsync(m => m.DesignerId == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // GET: Designer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designer designer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(designer);
        }

        // GET: Designer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Designers == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers.FindAsync(id);
            if (designer == null)
            {
                return NotFound();
            }
            return View(designer);
        }

        // POST: Designer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Designer designer)
        {
            if (id != designer.DesignerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignerExists(designer.DesignerId))
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
            return View(designer);
        }

        // GET: Designer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Designers == null)
            {
                return NotFound();
            }

            var designer = await _context.Designers
                .FirstOrDefaultAsync(m => m.DesignerId == id);
            if (designer == null)
            {
                return NotFound();
            }

            return View(designer);
        }

        // POST: Designer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Designers == null)
            {
                return Problem("Entity set 'ProductContext.Designers'  is null.");
            }
            var designer = await _context.Designers.FindAsync(id);
            if (designer != null)
            {
                _context.Designers.Remove(designer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignerExists(int id)
        {
          return (_context.Designers?.Any(e => e.DesignerId == id)).GetValueOrDefault();
        }
    }
}
