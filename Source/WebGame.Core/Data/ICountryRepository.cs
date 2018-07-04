using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Models.Geography;

namespace WebGame.Core.Data
{
    public interface ICountryRepository
    {
        Task<Country> Get(string name);
        Task<Country> GetRandom();
        Task<List<Country>> All();
        Task<Country> Add(Country country);
        Task<Country> Add(int country, int city);
    }
}
