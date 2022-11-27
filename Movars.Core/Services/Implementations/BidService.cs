using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Services.Implementations
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepo;

        public BidService(IBidRepository bidRepo)
        {
            _bidRepo = bidRepo;
        }

        public Task<bool> AddBid(Bid bid)
        {
            return _bidRepo.AddBid(bid);
        }

        public Task<bool> DeleteBid(Bid bid)
        {
            return (_bidRepo.DeleteBid(bid));
        }

        public Task<IEnumerable<Bid>> GetAllBidByMover(string id)
        {
            return _bidRepo.GetAllBidByMover(id);
        }

        public Task<IEnumerable<Bid>> GetAllBids()
        {
            return _bidRepo.GetAllBids();
        }

        public Task<IEnumerable<Bid>> GetAllBidsByDate(DateTime dateTime)
        {
            return _bidRepo.GetAllBidsByDate(dateTime);
        }

        public Task<IEnumerable<Bid>> GetAllBidsByStatus(BidStatus status)
        {
            return _bidRepo.GetAllBidsByStatus(status);
        }

        public Task<Bid> GetBidById(string id)
        {
            return _bidRepo.GetBidById(id);
        }

        public Task<bool> UpdateBid(Bid bid)
        {
            return _bidRepo.UpdateBid(bid);
        }
    }
}
