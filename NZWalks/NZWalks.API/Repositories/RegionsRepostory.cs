using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionsRepostory : IRegionsRepostory
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public RegionsRepostory(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }

        public IEnumerable<Region> GetAll()
        {
            return _nZWalksDbContext.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _nZWalksDbContext.Regions.ToListAsync();
        }

        
    }
}
