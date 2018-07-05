using GraphQL.Types;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models.Types
{
    public class PlanetType : ObjectGraphType<Planet>
    {
        public PlanetType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
        }
    }
}
