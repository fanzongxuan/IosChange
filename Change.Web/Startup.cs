using System;
using Change.Common.ElasticSearch;
using Change.Common.Logger;
using Change.Data;
using Change.Service.Extensions;
using Change.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Change.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Es configure
            services.Configure<ESOptions>(Configuration.GetSection("ElasticSearch"));
            services.AddSingleton<ESClientProvider>();

            // mysql connection
            var conn = Configuration.GetConnectionString("ChangeConnection");
            services.AddDbContextPool<ChangeDbContext>(options => options.UseMySql(conn));

            //my services
            services.AddMyServices();

            services.AddMvc();

            ServiceProvider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            //database auto migration
            var dbContext = ServiceProvider.GetService<ChangeDbContext>();
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //enable elastic search logger provier
            var opts = ServiceProvider.GetService<IOptions<ESOptions>>();
            if (opts != null && opts.Value.Enable)
            {
                loggerFactory.AddESLogger(ServiceProvider, Configuration.GetSection("Logging"));
            }


            app.UseMiddleware<ExceptionHandlerMiddleWare>();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Machine}/{action=List}/{id?}");
            });
        }
    }
}
