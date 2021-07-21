using System.Threading.Tasks;
using Bars.Homework.Common;
using Bars.Homework.MemoryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bars.Homework.MemoryManagement.Controllers
{
	/// <summary>
	/// Biz controller.
	/// </summary>
	public class SomeBizController : ApiControllerBase
	{
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
			await Task.CompletedTask;
			return Ok();
		}
	}
}