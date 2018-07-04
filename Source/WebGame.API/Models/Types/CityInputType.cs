using GraphQL.Types;

namespace WebGame.API.Models.Types
{
    public class CityInputType : InputObjectGraphType
    {
        public CityInputType()
        {
            Name = "CityInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
