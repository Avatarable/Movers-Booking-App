using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Models;
using Movars.Core.Models.Enums;
using Movars.Core.Services.Interfaces;

namespace Movars.Core.Services.Implementations
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepo;

        public RequestService(IRequestRepository requestRepo)
        {
            _requestRepo = requestRepo;
        }

        public Task<bool> CreateRequest(Request request)
        {
            return _requestRepo.CreateRequest(request);
        }

        public Task<bool> DeleteRequest(Request request)
        {
            return _requestRepo.DeleteRequest(request);
        }

        public Task<IEnumerable<Request>> GetAllRequests()
        {
            return _requestRepo.GetAllRequests();
        }

        public Task<IEnumerable<Request>> GetAllRequestsByAddress(Address address)
        {
            return _requestRepo.GetAllRequestsByAddress(address);
        }

        public Task<IEnumerable<Request>> GetAllRequestsByDate(DateTime dateTime)
        {
            return _requestRepo.GetAllRequestsByDate(dateTime);
        }

        public Task<IEnumerable<Request>> GetAllRequestsByOwner(string ownerId)
        {
            return _requestRepo.GetAllRequestsByOwner(ownerId);
        }

        public Task<IEnumerable<Request>> GetAllRequestsByStatus(RequestStatus status)
        {
            return _requestRepo.GetAllRequestsByStatus(status);
        }

        public Task<IEnumerable<Request>> GetAllRequestsByType(RequestType type)
        {
            return _requestRepo.GetAllRequestsByType(type);
        }

        public Task<Request> GetRequestById(string id)
        {
            return _requestRepo.GetRequestById(id);
        }

        public Task<bool> UpdateRequest(Request request)
        {
            return _requestRepo.UpdateRequest(request);
        }
    }
}
