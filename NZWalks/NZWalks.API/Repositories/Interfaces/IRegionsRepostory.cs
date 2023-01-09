using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Interfaces
{
    public interface IRegionsRepostory
    {
        IEnumerable<Region> GetAll();
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);
        Task<Region> UpdateAsync(Guid id, Region region);
        Task<Region> DeleteAsync(Guid id);

    }
}
