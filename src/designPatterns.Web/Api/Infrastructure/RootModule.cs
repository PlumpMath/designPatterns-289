using Nancy;

namespace designPatterns.Web.Api.Infrastructure
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => View["index.html"];
        }
    }
}