using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories
{
    public class WalksRepository : IWalkRepository
    {
        public Task<Region> AddAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Walk> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Walk>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Region> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
