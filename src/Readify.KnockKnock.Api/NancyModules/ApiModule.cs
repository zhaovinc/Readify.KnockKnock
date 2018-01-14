using Nancy;

namespace Readify.KnockKnock.Api.NancyModules
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Get("/Token", _ => GetToken());
        }

        private dynamic GetToken()
        {
            return Constants.APIToken;
        }
    }
}
