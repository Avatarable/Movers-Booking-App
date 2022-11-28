using Movars.Core.Models;
using Movars.Core.Models.Enums;

namespace Movars.Core.Data.Repositories.Interfaces
{
    public interface IRequestRepository
    {
        Task<bool> CreateRequest(Request request);
        Task<Request> GetRequestById(string id);
        Task<IEnumerable<Request>> GetAllRequests();
        Task<IEnumerable<Request>> GetAllRequestsByOwner(string ownerId);
        Task<IEnumerable<Request>> GetAllRequestsByDate(DateTime dateTime);
        Task<IEnumerable<Request>> GetAllRequestsByStatus(RequestStatus status);
        Task<IEnumerable<Request>> GetAllRequestsByType(RequestType type);
        Task<IEnumerable<Request>> GetAllRequestsByAddress(Address address);
        Task<bool> UpdateRequest(Request request);
        Task<bool> DeleteRequest(Request request);

    }
}
