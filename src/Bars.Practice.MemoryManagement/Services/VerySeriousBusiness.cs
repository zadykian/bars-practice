using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bars.Practice.MemoryManagement.DatabaseAccess;

namespace Bars.Practice.MemoryManagement.Services
{
	/// <inheritdoc />
	internal class VerySeriousBusiness : IVerySeriousBusiness
	{
		private readonly IDataAccessService dataAccessService;

		public VerySeriousBusiness(IDataAccessService dataAccessService)
			=> this.dataAccessService = dataAccessService;

		/// <inheritdoc />
		async Task IVerySeriousBusiness.ProcessObjectsAsync(Guid objectsGuid)
			=> (await dataAccessService.LoadAsync(objectsGuid))
				.ToList()
				.ForEach(bizObject =>
				{
					var fileName = Path.Combine(Environment.CurrentDirectory, "biz-objects.txt");
					File.AppendAllText(fileName, bizObject.ToString());
				});
	}
}