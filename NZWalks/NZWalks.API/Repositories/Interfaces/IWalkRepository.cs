using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IWalkRepository
    {
        IEnumerable<Walk> GetAll();

        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region> UpdateAsync(Guid id, Region region);

        Task<Region> DeleteAsync(Guid id);
    }
}
