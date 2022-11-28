using Microsoft.EntityFrameworkCore;
using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using System.Net;

namespace Movars.Core.Data.Repositories.Implementations
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateRequest(Request request)
        {
            _context.Add(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRequest(Request request)
        {
            _context.Remove(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByAddress(Address address)
        {
            return await _context.Requests.Where(x => x.PickupAddress == address).ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByDate(DateTime dateTime)
        {
            return await _context.Requests.Where(x => x.PickupDate == dateTime).ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByOwner(string ownerId)
        {
            return await _context.Requests.Include(x => x.PickupAddress).Include(x => x.DeliveryAddress)
                .Where(x => x.Owner.Id == ownerId).ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByStatus(RequestStatus status)
        {
            return await _context.Requests.Where(x => x.RequestStatus == status).ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByType(RequestType type)
        {
            return await _context.Requests.Where(x => x.RequestType == type).ToListAsync();
        }

        public async Task<Request> GetRequestById(string id)
        {
            return await _context.Requests.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateRequest(Request request)
        {
            _context.Update(request);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
