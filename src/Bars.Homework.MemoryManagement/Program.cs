using System.Linq;
using System.Threading.Tasks;
using Bars.Homework.Common;
using Microsoft.Extensions.Hosting;

namespace Bars.Homework.MemoryManagement
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
				.EnableHttpApi()
				.Build()
				.RunAsync();
	}
}