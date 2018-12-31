using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Department1.Data;
using Department1.Models;

namespace Department1.Controllers
{
    public class SupervisorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupervisorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Supervisors
        public async Task<IActionResult> Index()
        {
            return View(await _context.supervisors.ToListAsync());
        }

        // GET: Supervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisors = await _context.supervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisors == null)
            {
                return NotFound();
            }

            return View(supervisors);
        }

        // GET: Supervisors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supervisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SupervisorName")] Supervisors supervisors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supervisors);
        }

        // GET: Supervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisors = await _context.supervisors.FindAsync(id);
            if (supervisors == null)
            {
                return NotFound();
            }
            return View(supervisors);
        }

        // POST: Supervisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SupervisorName")] Supervisors supervisors)
        {
            if (id != supervisors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisorsExists(supervisors.Id))
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
            return View(supervisors);
        }

        // GET: Supervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisors = await _context.supervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supervisors == null)
            {
                return NotFound();
            }

            return View(supervisors);
        }

        // POST: Supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisors = await _context.supervisors.FindAsync(id);
            _context.supervisors.Remove(supervisors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisorsExists(int id)
        {
            return _context.supervisors.Any(e => e.Id == id);
        }
    }
}
