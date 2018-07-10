using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Core.Data;
using WebGame.Core.Models.Geography;

namespace WebGame.Data.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly WebGameContext _db;

        public PlanetRepository(WebGameContext db)
        {
            _db = db;
        }

        public async Task<Planet> Get(string name)
        {
            return await _db.Planets.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Planet> GetRandom()
        {
            return await _db.Planets.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Planet>> All()
        {
            return await _db.Planets.ToListAsync();
        }

        public async Task<Planet> Add(Planet planet)
        {
            await _db.Planets.AddAsync(planet);
            await _db.SaveChangesAsync();
            return planet;
        }

        public async Task<Planet> Add(int planet, int country)
        {
            var storedCountry = await _db.Countries.FirstOrDefaultAsync(p => p.Id == country);
            var storedPlanet = await _db.Planets.FirstOrDefaultAsync(p => p.Id == planet);
            if (storedPlanet.Countries == null)
                storedPlanet.Countries = new List<Country>();
            storedPlanet.Countries.Add(storedCountry);
            await _db.SaveChangesAsync();
            return storedPlanet;
        }
    }
}
