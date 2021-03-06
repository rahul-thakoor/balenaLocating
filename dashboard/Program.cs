using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace balenaLocatingDashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var run = Environment.GetEnvironmentVariable("RUN_DASHBOARD");
            if(null != run)
            {
                if("TRUE" == run.ToUpper())
                {
                    CreateHostBuilder(args).Build().Run();
                }
                else
                {
                    Console.WriteLine("Dashboard configured to not run, with env-var RUN_DASHBOARD set to: " + run);
                }
            }
            else
            {
                Console.WriteLine("Dashboard configured to not run. Add an environment variabled RUN_DASHBOARD set to: true");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
