using GraphQL.Types;
using WebGame.Core.Data;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models.Types
{
    public class PlanetType : ObjectGraphType<Planet>
    {
        public PlanetType(ICountryRepository countryRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field<ListGraphType<CountryType>>("countries",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => countryRepository.Get(context.Source.Id), description: "countries in the planet");

        }
    }
}
