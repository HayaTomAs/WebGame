using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Models.Geography;
namespace WebGame.Core.Data
{
    public interface ICityRepository
    {
        Task<List<City>> Get(int id);
        Task<City> Get(string name);
        Task<City> GetRandom();
        Task<List<City>> All();
        Task<City> Add(City city);
    }
}
