using GraphQL.Types;

namespace WebGame.API.Models.Types
{
    public class PlanetInputType : InputObjectGraphType
    {
        public PlanetInputType()
        {
            Name = "PlanetInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
