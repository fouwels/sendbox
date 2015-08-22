using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Hosting.Internal;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using Microsoft.Framework.Runtime;

namespace proj
{
    public class Startup
    {
		public IConfiguration Configuration { get; set; }
		public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
		{
			var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
				.AddJsonFile("config.json")
				.AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

			if (env.IsDevelopment())
			{
				builder.AddUserSecrets();
			}

			builder.AddEnvironmentVariables();
			//builder.AddUserSecrets();
			Configuration = builder.Build();
		}
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddMvc().ConfigureMvcViews(options =>
	        {
		        options.ViewEngines.Add(Type.GetType("proj.ViewEngines.DefaultViewEngine"));
	        });

			services.AddLogging();

			Debug.WriteLine("Configured Services - " + Configuration["Data:CheckVal"]); // indentify config mis match
        }

		public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory, ILogger<Startup> logger)
		{
			LoggerFactory.AddConsole(LogLevel.Information);

			app.Use(async (context, next) =>
			{
				var s = ("[Pipeline] Request to:" + context.Request.Path);
				logger.LogInformation(s);
				Debug.WriteLine(s);
				await next();
			});

			app.UseStaticFiles();
			app.UseErrorPage();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Page", action = "Index" });
			});
		}
    }
}
