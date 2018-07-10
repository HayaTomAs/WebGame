
using GraphQL.Types;

namespace WebGame.API.Models.Types
{
    public class SetCityInputType : InputObjectGraphType
    {
        public SetCityInputType()
        {
            Name = "AddCityInput";
            Field<NonNullGraphType<IntGraphType>>("player");
            Field<NonNullGraphType<IntGraphType>>("city");
        }
    }
}
