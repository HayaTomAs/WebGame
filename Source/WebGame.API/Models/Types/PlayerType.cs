
using GraphQL.Types;
using WebGame.Core.Data;
using WebGame.Core.Models;

namespace WebGame.API.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType()
        {
            Field(x => x.Id);
            Field(x => x.Pseudo, true);
        }
    }
}
