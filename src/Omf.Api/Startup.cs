using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omf.Common.Events;
using Omf.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Omf.Api.Handlers;
using Microsoft.Extensions.Options;
using Omf.Common.Auth;
using Omf.Api.Repositories;
using Omf.Common.Mongo;
using Omf.Common.Commands;

namespace Omf.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMongoDB(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddJwt(Configuration);
            services.AddTransient<IEventHandler<OrderCreated>, OrderCreatedHandler>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IEventHandler<ReviewCreated>, ReviewCreatedHandler>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IEventHandler<RestaurantCreated>, RestaurantCreatedHandler>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
