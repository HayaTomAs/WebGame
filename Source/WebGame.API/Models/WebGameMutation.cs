using GraphQL.Types;
using System.Collections.Generic;
using WebGame.API.Models.Types;
using WebGame.Core.Data;
using WebGame.Core.Models;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models
{
    public class WebGameMutation : ObjectGraphType
    {
        public WebGameMutation(
            IPlayerRepository playerRepository,
            IPlanetRepository planetRepository,
            ICountryRepository countryRepository,
            ICityRepository cityRepository
            )
        {
            //Name = "CreatePlayerMutation";

            Field<PlayerType>(
                "createPlayer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerInputType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var player = context.GetArgument<Player>("player");
                    return playerRepository.Add(player);
                });

            Field<PlanetType>(
                "createPlanet",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlanetInputType>> { Name = "planet" }
                ),
                resolve: context =>
                {
                    var planet = context.GetArgument<Planet>("planet");
                    return planetRepository.Add(planet);
                });



            Field<CountryType>(
                "createCountry",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CountryInputType>> { Name = "country" }
                ),
                resolve: context =>
                {
                    var country = context.GetArgument<Country>("country");
                    return countryRepository.Add(country);
                });



            Field<CityType>(
                "createCity",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CityInputType>> { Name = "city" }
                ),
                resolve: context =>
                {
                    var city = context.GetArgument<City>("city");
                    return cityRepository.Add(city);
                });

            Field<CityType>(
                "addCity",
                arguments: new QueryArguments(new[] {
                    new QueryArgument<NonNullGraphType<AddCityInputType>> { Name = "cityLink" },
                    }
                ),
                resolve: context =>
                {
                    
                    var dico = (Dictionary<string, object>)context.Arguments["cityLink"];
                    var country = (int)dico["country"];
                    var city = (int)dico["city"];
                    return countryRepository.Add(country, city);
                });

            Field<PlanetType>(
                "addCoutry",
                arguments: new QueryArguments(new[] {
                    new QueryArgument<NonNullGraphType<AddCountryInputType>> { Name = "countryLink" },
                    }
                ),
                resolve: context =>
                {

                    var dico = (Dictionary<string, object>)context.Arguments["countryLink"];
                    var planet = (int)dico["planet"];
                    var country = (int)dico["country"];
                    return planetRepository.Add(planet, country);
                });



            Field<PlayerType>(
                "setCity",
                arguments: new QueryArguments(new[] {
                    new QueryArgument<NonNullGraphType<SetCityInputType>> { Name = "cityLink" },
                    }
                ),
                resolve: context =>
                {

                    var dico = (Dictionary<string, object>)context.Arguments["cityLink"];
                    var player = (int)dico["player"];
                    var city = (int)dico["city"];
                    return playerRepository.Add(player, city);
                });
        }
    }
}
