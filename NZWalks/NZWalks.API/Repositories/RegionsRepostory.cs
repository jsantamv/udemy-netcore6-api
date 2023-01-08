using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories.Interfaces;

namespace NZWalks.API.Repositories
{
    public class RegionsRepostory : IRegionsRepostory
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public RegionsRepostory(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _nZWalksDbContext.AddAsync(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return null;
            }

            //Delete Region from database
            _nZWalksDbContext.Regions.Remove(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }


        public IEnumerable<Region> GetAll()
        {
            return _nZWalksDbContext.Regions.ToList();
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existRegion = await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existRegion == null)
            {
                return null;
            }

            existRegion.Code= region.Code;
            existRegion.Name= region.Name;  
            existRegion.Area= region.Area;
            existRegion.Lat= region.Lat;
            existRegion.Long= region.Long;
            existRegion.Population= region.Population;

            await _nZWalksDbContext.SaveChangesAsync();
            return existRegion;
        }
    }
}
