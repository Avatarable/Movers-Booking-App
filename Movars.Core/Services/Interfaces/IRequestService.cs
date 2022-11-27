using Movars.Core.Models.Enums;
using Movars.Core.Models;

namespace Movars.Core.Services.Interfaces
{
    public interface IRequestService
    {
        Task<bool> CreateRequest(Request request);
        Task<Request> GetRequestById(string id);
        Task<IEnumerable<Request>> GetAllRequests();
        Task<IEnumerable<Request>> GetAllRequestsByOwner(string id);
        Task<IEnumerable<Request>> GetAllRequestsByDate(DateTime dateTime);
        Task<IEnumerable<Request>> GetAllRequestsByStatus(RequestStatus status);
        Task<IEnumerable<Request>> GetAllRequestsByType(RequestType type);
        Task<IEnumerable<Request>> GetAllRequestsByAddress(Address address);
        Task<bool> UpdateRequest(Request request);
        Task<bool> DeleteRequest(Request request);
    }
}
