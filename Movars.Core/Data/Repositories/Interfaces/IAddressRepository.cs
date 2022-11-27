using Movars.Core.Models;

namespace Movars.Core.Data.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<bool> AddAddressAsync(Address address);
        Task<Address> GetAddressAsync(string id);
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<IEnumerable<Address>> GetAddressesByStateAsync(string state);
        Task<IEnumerable<Address>> GetAddressesByCity(string city);
        Task<bool> UpdateAddress(Address address);
    }
}
