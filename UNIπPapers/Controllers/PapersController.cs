﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UNIπPapers.Data;
using UNIπPapers.Models;

namespace UNIπPapers.Controllers
{
    public class PapersController : Controller
    {
        private readonly UNIπPapersContext _context;

        public PapersController(UNIπPapersContext context)
        {
            _context = context;
        }

        // GET: Papers
        public async Task<IActionResult> Index(string paperColor, string searchString)
        {
            if (_context.Paper == null)
            {
                return Problem("Entity set 'UNIπPapersContext.Paper'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> colorQuery = from m in _context.Paper
                                            orderby m.Color
                                            select m.Color;
            var papers = from m in _context.Paper
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                papers = papers.Where(s => s.PaperType!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(paperColor))
            {
                papers = papers.Where(x => x.Color == paperColor);
            }

            var paperColorVM = new PaperColorViewModel
            {
                Colors = new SelectList(await colorQuery.Distinct().ToListAsync()),
                Papers = await papers.ToListAsync()
            };

            return View(paperColorVM);
        }

        // GET: Papers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // GET: Papers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Papers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaperType,Color,Size,Thickness,Qty,Price,Reviews")] Paper paper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paper);
        }

        // GET: Papers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper.FindAsync(id);
            if (paper == null)
            {
                return NotFound();
            }
            return View(paper);
        }

        // POST: Papers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PaperType,Color,Size,Thickness,Qty,Price,Reviews")] Paper paper)
        {
            if (id != paper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperExists(paper.Id))
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
            return View(paper);
        }

        // GET: Papers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paper = await _context.Paper
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paper == null)
            {
                return NotFound();
            }

            return View(paper);
        }

        // POST: Papers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paper = await _context.Paper.FindAsync(id);
            if (paper != null)
            {
                _context.Paper.Remove(paper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperExists(int id)
        {
            return _context.Paper.Any(e => e.Id == id);
        }
    }
}
