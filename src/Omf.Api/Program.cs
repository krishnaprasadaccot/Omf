using Omf.Common.Events;
using Omf.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Omf.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .SubscribeToEvent<OrderCreated>()
                .SubscribeToEvent<ReviewCreated>()
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
