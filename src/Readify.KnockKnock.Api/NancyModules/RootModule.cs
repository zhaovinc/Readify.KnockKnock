using Nancy;
using Nancy.Responses;

namespace Readify.KnockKnock.Api.NancyModules
{
    public class RootModule : NancyModule
    {
        public RootModule() : base("/")
        {
            Get("", o => { return new TextResponse("Welcome to Readify.KnockKnock API"); });
        }
    }
}