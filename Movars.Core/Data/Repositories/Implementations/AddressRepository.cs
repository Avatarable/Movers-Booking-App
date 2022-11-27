using Microsoft.EntityFrameworkCore;
using Movars.Core.Data.Repositories.Interfaces;
using Movars.Core.Models;

namespace Movars.Core.Data.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAddressAsync(Address address)
        {
            _context.Add(address);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Address> GetAddressAsync(string id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<IEnumerable<Address>> GetAddressesByCity(string city)
        {
            return await _context.Addresses.Where(x => x.City == city).ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressesByStateAsync(string state)
        {
            return await _context.Addresses.Where(x => x.State == state).ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            _context.Update(address);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
