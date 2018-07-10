
using GraphQL.Types;
using WebGame.API.Models.Types;
using WebGame.Core.Data;
using WebGame.Core.Models;

namespace WebGame.API.Models
{
    public class PlayerType : ObjectGraphType<Player>
    {
        public PlayerType(ICityRepository cityRepository)
        {
            Field(x => x.Id);
            Field(x => x.Pseudo, true);
            Field<CityType>("city",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => cityRepository.GetById(context.Source.Id), description: "City of the player");


        }
    }
}
