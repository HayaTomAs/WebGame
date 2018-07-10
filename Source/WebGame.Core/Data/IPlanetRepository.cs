using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Models.Geography;

namespace WebGame.Core.Data
{
    public interface IPlanetRepository
    {
        Task<Planet> Get(string name);
        Task<Planet> GetRandom();
        Task<List<Planet>> All();
        Task<Planet> Add(Planet planet);
        Task<Planet> Add(int planet, int country);
    }
}
