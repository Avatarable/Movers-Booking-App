using Movars.Core.Models.Enums;
using Movars.Core.Models;

namespace Movars.Core.Data.Repositories.Interfaces
{
    public interface IBidRepository
    {
        Task<bool> AddBid(Bid bid);
        Task<Bid> GetBidById(string id);
        Task<IEnumerable<Bid>> GetAllBids();
        Task<IEnumerable<Bid>> GetAllBidsByMover(string moverId);
        Task<IEnumerable<Bid>> GetAllBidsByDate(DateTime dateTime);
        Task<IEnumerable<Bid>> GetAllBidsByStatus(BidStatus status);
        Task<bool> UpdateBid(Bid bid);
        Task<bool> DeleteBid(Bid bid);
    }
}
