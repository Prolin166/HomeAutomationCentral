using AutoMapper;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Domain.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace HomeAutomationCentral
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Device, DeviceModel>().ForPath(d => d.AreaId, o => o.MapFrom(s => s.Area.AreaId));
                cfg.CreateMap<Area, AreaModel>();                
             });
            mapperConfig.AssertConfigurationIsValid();

            //var mapperConfigRoom = new MapperConfiguration(cfg => cfg.CreateMap<Area, AreaModel>());

            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>().UseUrls("http://*:5000", "https://*:5001");
                })
                .ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                
                .UseNLog();  // NLog: Setup NLog for Dependency injection

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logBuilder =>
                 {
                     logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                     logBuilder.AddConsole();
                     logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
                 })
                .UseStartup<Startup>();
        }
    }

