using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Readify.KnockKnock.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup.Startup>()
                .UseKestrel()
                .UseUrls("http://+:5000")
                .Build();
        }
    }
}
