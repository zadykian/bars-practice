using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bars.Homework.MemoryManagement.Controllers
{
	/// <summary>
	/// Biz controller.
	/// </summary>
	public class SomeBizController : ControllerBase
	{
		/// <summary>
		/// Do some very serious business asynchronously.
		/// </summary>
		public async Task<IActionResult> DoSomeSeriousBusiness()
		{
			await Task.CompletedTask;
			return Ok();
		}
	}
}