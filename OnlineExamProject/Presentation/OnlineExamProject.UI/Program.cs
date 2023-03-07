using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.Seq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamProject.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json").
				Build();
			Log.Logger = new LoggerConfiguration()
					.WriteTo.Console()
					.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
					.WriteTo.MSSqlServer(configuration.GetConnectionString("SQLServer"), "logs", autoCreateSqlTable: true) 
					.MinimumLevel.Information()
					.CreateLogger();
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{

					webBuilder.UseStartup<Startup>();
				}).UseSerilog()
			;
	
	}
}
