﻿using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSwag.AspNetCore;

namespace Roadkill.Api
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder();
			builder
				.SetBasePath(Path.Combine(env.ContentRootPath))
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
				.AddEnvironmentVariables();

			Configuration = builder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			string connectionString = Configuration["ConnectionString"];

			Roadkill.Core.DependencyInjection.ConfigureServices(services, connectionString);
			Roadkill.Api.DependencyInjection.ConfigureServices(services);

			services.AddMvc();
			services.AddOptions();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseExceptionHandler("/error");
			app.UseSwagger(Assembly.GetEntryAssembly());
			app.UseSwaggerUi(Assembly.GetEntryAssembly());
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}