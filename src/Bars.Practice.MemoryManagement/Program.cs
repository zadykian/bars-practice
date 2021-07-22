using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bars.Practice.Common;
using Bars.Practice.MemoryManagement.DatabaseAccess;
using Bars.Practice.MemoryManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace Bars.Practice.MemoryManagement
{
	/// <summary>
	/// Application entry point. 
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// Entry point method. 
		/// </summary>
		private static Task Main(string[] args)
			=> Host
				.CreateDefaultBuilder(args.ToArray())
				.UseDefaultServiceProvider(options =>
				{
					options.ValidateScopes = true;
					options.ValidateOnBuild = true;
				})
				.ConfigureServices(ConfigureServices)
				.EnableHttpApi()
				.Build()
				.RunAsync();

		/// <summary>
		/// Configure application services. 
		/// </summary>
		private static void ConfigureServices(IServiceCollection services)
			=> services
				.AddScoped<IDbConnection>(provider => provider
					.GetRequiredService<IConfiguration>()
					.GetConnectionString("Default")
					.To(connectionString => new NpgsqlConnection(connectionString)))
				.AddScoped<IDataAccessService, DataAccessService>()
				.AddScoped<IVerySeriousBusiness, VerySeriousBusiness>();
	}
}