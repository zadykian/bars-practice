using System.Linq;
using System.Threading.Tasks;
using Bars.Practice.Common;
using Bars.Practice.MemoryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bars.Practice.MemoryManagement.Controllers
{
	/// <summary>
	/// Biz controller.
	/// </summary>
	public class SomeBizController : ApiControllerBase
	{
		private static int CallCount => 1024;

		private readonly IVerySeriousBusiness verySeriousBusiness;

		/// <param name="verySeriousBusiness">
		/// A very serious business service.
		/// </param>
		public SomeBizController(IVerySeriousBusiness verySeriousBusiness)
			=> this.verySeriousBusiness = verySeriousBusiness;

		/// <summary>
		/// Do some very serious business asynchronously.
		/// </summary>
		[HttpPost]
		public async Task<IActionResult> DoSomeSeriousBusinessAsync()
		{
			await AsyncEnumerable
				.Range(0, CallCount)
				.ForEachAwaitAsync(async _ => await verySeriousBusiness.DoItAsync());

			return Ok();
		}
	}
}