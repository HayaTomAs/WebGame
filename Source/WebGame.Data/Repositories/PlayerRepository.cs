using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGame.Core.Data;
using WebGame.Core.Models;

namespace WebGame.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly WebGameContext _db;

        public PlayerRepository(WebGameContext db)
        {
            _db = db;
        }

        public async Task<Player> Get(string pseudo)
        {
            return await _db.Players.FirstOrDefaultAsync(p => p.Pseudo == pseudo);
        }

        public async Task<Player> GetRandom()
        {
            return await _db.Players.OrderBy(o => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<Player>> All()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<Player> Add(Player player)
        {
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player> Add(int player, int city)
        {
            var storedPlayer = await _db.Players.FirstOrDefaultAsync(p => p.Id == player);
            var storedCity = await _db.Cities.FirstOrDefaultAsync(p => p.Id == city);
            storedPlayer.City = storedCity;
            await _db.SaveChangesAsync();
            return storedPlayer;
        }
    }
}
