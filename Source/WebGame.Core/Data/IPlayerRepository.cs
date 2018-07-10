using System.Collections.Generic;
using System.Threading.Tasks;
using WebGame.Core.Models;

namespace WebGame.Core.Data
{
    public interface IPlayerRepository
    {
        Task<Player> Get(string pseudo);
        Task<Player> GetRandom();
        Task<List<Player>> All();
        Task<Player> Add(Player player);
        Task<Player> Add(int player, int city);
    }
}
