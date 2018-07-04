using GraphQL.Types;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models.Types
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType()
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
        }
    }
}
