using GraphQL.Types;
using WebGame.Core.Models.Geography;

namespace WebGame.API.Models.Types
{
    public class AddCityInputType : InputObjectGraphType
    {
        public AddCityInputType()
        {
            Name = "AddCityInput";
            Field<NonNullGraphType<IntGraphType>>("country");
            Field<NonNullGraphType<IntGraphType>>("city");
        }
    }
}
