using GraphQL.Types;

namespace WebGame.API.Models
{
    public class PlayerInputType : InputObjectGraphType
    {
        public PlayerInputType()
        {
            Name = "PlayerInput";
            Field<NonNullGraphType<StringGraphType>>("pseudo");
        }
    }
}
