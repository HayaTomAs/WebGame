using GraphQL.Types;

namespace WebGame.API.Models.Types
{
    public class AddCountryInputType : InputObjectGraphType
    {
        public AddCountryInputType()
        {
            Name = "AddCountryInput";
            Field<NonNullGraphType<IntGraphType>>("planet");
            Field<NonNullGraphType<IntGraphType>>("country");
        }
    }
}
