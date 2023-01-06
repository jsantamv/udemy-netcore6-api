using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionsRepostory
    {
        IEnumerable<Region> GetAll();
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
