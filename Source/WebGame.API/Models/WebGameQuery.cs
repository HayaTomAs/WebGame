using GraphQL.Types;
using WebGame.API.Models.Types;
using WebGame.Core.Data;

namespace WebGame.API.Models
{
    public class WebGameQuery : ObjectGraphType
    {
        public WebGameQuery(
            IPlayerRepository playerRepository,
            IPlanetRepository planetRepository,
            ICountryRepository countryRepository,
            ICityRepository cityRepository
        )
        {
            Field<PlayerType>(
                "player",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "pseudo" }),
                resolve: context => playerRepository.Get(context.GetArgument<string>("pseudo")));

            Field<PlayerType>(
                "randomPlayer",
                resolve: context => playerRepository.GetRandom());

            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => playerRepository.All());

            Field<PlanetType>(
                "planet",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => planetRepository.Get(context.GetArgument<string>("name")));

            Field<PlanetType>(
                "randomPlanet",
                resolve: context => planetRepository.GetRandom());

            Field<ListGraphType<PlanetType>>(
                "planets",
                resolve: context => planetRepository.All());

            Field<CountryType>(
                "country",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => countryRepository.Get(context.GetArgument<string>("name")));

            Field<CountryType>(
                "randomCountry",
                resolve: context => countryRepository.GetRandom());

            Field<ListGraphType<CountryType>>(
                "countries",
                resolve: context => countryRepository.All());


            Field<CityType>(
                "city",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => countryRepository.Get(context.GetArgument<string>("name")));

            Field<CityType>(
                "randomCity",
                resolve: context => cityRepository.GetRandom());

            Field<ListGraphType<CityType>>(
                "cities",
                resolve: context => cityRepository.All());
        }
    }
}

