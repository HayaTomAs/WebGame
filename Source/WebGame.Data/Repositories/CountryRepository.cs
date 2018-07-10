using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Core.Data;
using WebGame.Core.Models.Geography;

namespace WebGame.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly WebGameContext _db;

        public CountryRepository(WebGameContext db)
        {
            _db = db;
        }

        public async Task<List<Country>> Get(int id)
        {
            var planet = await _db.Planets.Include(x => x.Countries)
                .FirstOrDefaultAsync(p => p.Id == id);

            return planet.Countries.ToList();
        }

        public async Task<Country> Get(string name)
        {
            return await _db.Countries.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Country> GetRandom()
        {
            return await _db.Countries.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Country>> All()
        {
            return await _db.Countries.ToListAsync();
        }

        public async Task<Country> Add(Country country)
        {
            await _db.Countries.AddAsync(country);
            await _db.SaveChangesAsync();
            return country;
        }



        public async Task<Country> Add(int country, int city)
        {
            var storedCountry = await _db.Countries.FirstOrDefaultAsync(p => p.Id == country);
            var storedCity = await _db.Cities.FirstOrDefaultAsync(p => p.Id == city);
            if (storedCountry.Cities == null)
                storedCountry.Cities = new List<City>();
            storedCountry.Cities.Add(storedCity);
            await _db.SaveChangesAsync();
            return storedCountry;
        }
    }
}
