using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movars.Core.Data;
using Movars.Core.Models;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Controllers
{
    public class BidsController : Controller
    {
        private readonly IBidService _bidService;

        public BidsController(IBidService bidService)
        {
            _bidService = bidService;
        }

        // GET: Bids
        public async Task<IActionResult> Index()
        {
              return View(await _bidService.GetAllBids());
        }

        // GET: Bids/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _bidService.GetAllBids() == null)
            {
                return NotFound();
            }

            var bid = await _bidService.GetBidById(id);
            if (bid == null)
            {
                return NotFound();
            }

            return View(bid);
        }

        // GET: Bids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,DateCreated,Status")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(bid);
        }

        // GET: Bids/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            //if (id == null || _context.Bids == null)
            //{
            //    return NotFound();
            //}

            //var bid = await _context.Bids.FindAsync(id);
            //if (bid == null)
            //{
            //    return NotFound();
            //}
            //return View(bid);
            return View();
        }

        // POST: Bids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Amount,DateCreated,Status")] Bid bid)
        {
            if (id != bid.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(bid);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidExists(bid.Id))
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
            return View(bid);
        }

        // GET: Bids/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            //if (id == null || _context.Bids == null)
            //{
            //    return NotFound();
            //}

            //var bid = await _context.Bids
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (bid == null)
            //{
            //    return NotFound();
            //}

            //return View(bid);
            return View();
        }

        // POST: Bids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //if (_context.Bids == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Bids'  is null.");
            //}
            //var bid = await _context.Bids.FindAsync(id);
            //if (bid != null)
            //{
            //    _context.Bids.Remove(bid);
            //}
            
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidExists(string id)
        {
            //return _context.Bids.Any(e => e.Id == id);
            return true;
        }
    }
}
