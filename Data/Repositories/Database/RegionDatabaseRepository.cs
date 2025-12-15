using Tp_Final_Fred.Models;
using Tp_Final_Fred.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Final_Fred.Data.Repositories.Database
{
    public class RegionDatabaseRepository : IRegionRepository
    {
        private readonly MeteoDbContext _context = new();

        public RegionDatabaseRepository(MeteoDbContext context)
        {
            _context = context;
        }

        public List<Region> GetAll()
            => _context.Regions.OrderBy(r => r.Name).ToList();

        public async Task<List<Region>> GetAllAsync()
            => await _context.Regions.OrderBy(r => r.Name).ToListAsync();

        public async Task<Region> AddAsync(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            return region;
        }
    }
}
