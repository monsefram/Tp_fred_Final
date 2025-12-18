using Tp_Final_Fred.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tp_Final_Fred.Data.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        List<Region> GetAll();
        Task<List<Region>> GetAllAsync();
        Task<Region> AddAsync(Region region);
        Task DeleteAsync(Region region);
    }
}
