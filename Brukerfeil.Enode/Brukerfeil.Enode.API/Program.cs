using Brukerfeil.Enode.API.Configurations;
using Brukerfeil.Enode.Common.Configurations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Brukerfeil.Enode.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
