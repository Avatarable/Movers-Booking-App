using Microsoft.EntityFrameworkCore;
using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using System;

namespace Movars.Core.Data.Repositories.Implementations
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext _context;

        public BidRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBid(Bid bid)
        {
            _context.Add(bid);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBid(Bid bid)
        {
            _context.Remove(bid);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Bid>> GetAllBidsByMover(string moverId)
        {
            return await _context.Bids.Include(b =>b.Request).Include(u => u.Mover)
                .Where(x => x.Mover.Id == moverId).ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetAllBids()
        {
            return await _context.Bids.Include(b => b.Request).Include(u => u.Mover)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetAllBidsByDate(DateTime dateTime)
        {
            return await _context.Bids.Include(b => b.Request).Include(u => u.Mover)
                .Where(x => x.DateCreated == dateTime).ToListAsync();
        }

        public async Task<IEnumerable<Bid>> GetAllBidsByStatus(BidStatus status)
        {
            return await _context.Bids.Include(b => b.Request).Include(u => u.Mover)
                .Where(x => x.Status == status).ToListAsync();
        }

        public async Task<Bid> GetBidById(string id)
        {
            return await _context.Bids.Include(u => u.Mover)
                .Include(b => b.Request).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateBid(Bid bid)
        {
            _context.Update(bid);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
