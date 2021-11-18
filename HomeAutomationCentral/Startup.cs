using AutoMapper;
using HomeAutomationCentral.Business;
using HomeAutomationCentral.Business.Backgroundtasks;
using HomeAutomationCentral.Business.HWEndpoints.Contacts;
using HomeAutomationCentral.Business.Services;
using HomeAutomationCentral.Business.Services.Contracts;
using HomeAutomationCentral.Domain;
using HomeAutomationCentral.Endpoint.HWEndpoints.Options;
using HomeAutomationCentral.Mappings;
using HomeAutomationCentral.Services;
using HomeAutomationCentral.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Text.Json;

namespace HomeAutomationCentral
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
            services.AddEntityFrameworkSqlite().AddDbContext<HomeAutomationCentralDbContext>();
            services.AddTransient<IEndpoint, ESPEndpoint>();
            services.AddTransient<IEndpoint, HueEndpoint>();
            services.AddTransient<IHueEndpoint, HueEndpoint>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IManagementHandler, ManagementHandler>();
            services.AddSingleton<EndpointFactory>();
            services.AddSingleton<HueUpdater>();
            services.AddControllers();
            services.Configure<HueEndpointOptions>(Configuration.GetSection("HueEndpointOptions"));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var client = scope.ServiceProvider.GetService<HomeAutomationCentralDbContext>())
                {
                    client.Database.EnsureCreated();
                    client.Database.Migrate();
                }

            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
