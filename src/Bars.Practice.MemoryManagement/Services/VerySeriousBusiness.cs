using System;
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
		{
			var objectsFromSingleGroup = (await dataAccessService.LoadAsync(objectsGuid)).ToArray();
		}
	}
}