using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Chane.Api.Middleware;
using Change.Common.ElasticSearch;
using Change.Common.Logger;
using Change.Data;
using Change.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;

namespace Chane.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ServiceProvider { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // mysql connection
            var conn = Configuration.GetConnectionString("ChangeConnection");
            services.AddDbContextPool<ChangeDbContext>(options => options.UseMySql(conn));

            //Es configure
            services.Configure<ESOptions>(Configuration.GetSection("ElasticSearch"));
            services.AddSingleton<ESClientProvider>();

            //my services
            services.AddMyServices();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Chane.Api.xml");
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllEnumsAsStrings();
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //字符串输出枚举
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                //设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                //NULL值忽略
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            }); ;
            ServiceProvider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //enable elastic search logger provier
            var opts = ServiceProvider.GetService<IOptions<ESOptions>>();
            if (opts != null && opts.Value.Enable)
            {
                loggerFactory.AddESLogger(ServiceProvider, Configuration.GetSection("Logging"));
            }

            //database auto migration
            var dbContext = ServiceProvider.GetService<ChangeDbContext>();
            dbContext.Database.Migrate();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.ShowJsonEditor();
                c.ShowRequestHeaders();
            });

            //异常处理
            app.UseMiddleware<ExceptionHandlerMiddleWare>();

            app.UseMvc();
        }
    }
}
