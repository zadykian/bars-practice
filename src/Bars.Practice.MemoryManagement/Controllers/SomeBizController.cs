using System;
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
		/// <param name="objectsGuid" example="82433680-da5f-49c3-a116-06af6fcad5df">
		/// Objects' group identifier.
		/// </param>
		[HttpPost]
		public async Task<IActionResult> DoSomeSeriousBusinessAsync([FromQuery] Guid objectsGuid)
		{
			await AsyncEnumerable
				.Range(0, CallCount)
				.ForEachAwaitAsync(async _ => await verySeriousBusiness.ProcessObjectsAsync(objectsGuid));

			return Ok();
		}
	}
}