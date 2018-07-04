using GraphQL;
using GraphQL.Types;

namespace WebGame.API.Models
{
    public class WebGameSchema : Schema
    {
        public WebGameSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<WebGameQuery>();
            Mutation = resolver.Resolve<WebGameMutation>();
        }
    }
}
