using GraphQL.Types;

namespace WebGame.API.Models.Types
{
    public class CountryInputType : InputObjectGraphType
    {
        public CountryInputType()
        {
            Name = "CountryInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
