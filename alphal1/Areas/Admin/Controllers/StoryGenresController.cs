using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alphal1.Models;
using alphal1.Models;

namespace alphal1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoryGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoryGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/StoryGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StoryGenres.Include(s => s.Genre).Include(s => s.Story);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/StoryGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyGenre = await _context.StoryGenres
                .Include(s => s.Genre)
                .Include(s => s.Story)
                .FirstOrDefaultAsync(m => m.StoryId == id);
            if (storyGenre == null)
            {
                return NotFound();
            }

            return View(storyGenre);
        }

        // GET: Admin/StoryGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            ViewData["StoryId"] = new SelectList(_context.Stories, "Id", "Id");
            return View();
        }

        // POST: Admin/StoryGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoryId,GenreId")] StoryGenre storyGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storyGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", storyGenre.GenreId);
            ViewData["StoryId"] = new SelectList(_context.Stories, "Id", "Id", storyGenre.StoryId);
            return View(storyGenre);
        }

        // GET: Admin/StoryGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyGenre = await _context.StoryGenres.FindAsync(id);
            if (storyGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", storyGenre.GenreId);
            ViewData["StoryId"] = new SelectList(_context.Stories, "Id", "Id", storyGenre.StoryId);
            return View(storyGenre);
        }

        // POST: Admin/StoryGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoryId,GenreId")] StoryGenre storyGenre)
        {
            if (id != storyGenre.StoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storyGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryGenreExists(storyGenre.StoryId))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", storyGenre.GenreId);
            ViewData["StoryId"] = new SelectList(_context.Stories, "Id", "Id", storyGenre.StoryId);
            return View(storyGenre);
        }

        // GET: Admin/StoryGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storyGenre = await _context.StoryGenres
                .Include(s => s.Genre)
                .Include(s => s.Story)
                .FirstOrDefaultAsync(m => m.StoryId == id);
            if (storyGenre == null)
            {
                return NotFound();
            }

            return View(storyGenre);
        }

        // POST: Admin/StoryGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storyGenre = await _context.StoryGenres.FindAsync(id);
            if (storyGenre != null)
            {
                _context.StoryGenres.Remove(storyGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryGenreExists(int id)
        {
            return _context.StoryGenres.Any(e => e.StoryId == id);
        }
    }
}
