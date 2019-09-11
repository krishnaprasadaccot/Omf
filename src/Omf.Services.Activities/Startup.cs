using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omf.Common.Commands;
using Omf.Common.Events;
using Omf.Common.Mongo;
using Omf.Common.RabbitMq;
using Omf.Services.Activities.Domain.Repositories;
using Omf.Services.Activities.Handlers;
using Omf.Services.Activities.Repositories;
using Omf.Services.Activities.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Omf.Services.Activities
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
            //services.AddLogging();
            services.AddRabbitMq(Configuration);
            services.AddMongoDB(Configuration);
            services.AddTransient<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IDatabaseSeeder, CustomMongoSeeder>();
            services.AddTransient<IActivityService, ActivityService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseHttpsRedirection();
            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            app.UseMvc();
        }
    }
}
