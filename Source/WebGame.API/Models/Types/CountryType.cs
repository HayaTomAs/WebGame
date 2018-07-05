using GraphQL.Types;
using WebGame.Core.Data;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models.Types
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType(ICityRepository cityRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name, true);
            Field<ListGraphType<CityType>>("cities",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => cityRepository.Get(context.Source.Id), description: "Cities in the country");

        }
    }
}
