using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Core.Data;
using WebGame.Core.Models.Geography;

namespace WebGame.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly WebGameContext _db;

        public CityRepository(WebGameContext db)
        {
            _db = db;
        }


        public async Task<City> GetById(int id)
        {
            var player = await _db.Players.Include(x => x.City).FirstOrDefaultAsync(p => p.Id == id);
            return player.City;
        }
        public async Task<List<City>> Get(int id)
        {
            var country = await _db.Countries.Include(x => x.Cities)
                .FirstOrDefaultAsync(p => p.Id == id); 

            return country.Cities.ToList();
        }

        public async Task<City> Get(string name)
        {
            return await _db.Cities.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<City> GetRandom()
        {
            return await _db.Cities.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<City>> All()
        {
            return await _db.Cities.ToListAsync();
        }

        public async Task<City> Add(City city)
        {
            await _db.Cities.AddAsync(city);
            await _db.SaveChangesAsync();
            return city;
        }
    }
}
