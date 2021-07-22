using System;
using System.Threading.Tasks;

namespace Bars.Practice.MemoryManagement.Services
{
	/// <summary>
	/// A very serious business service.
	/// </summary>
	public interface IVerySeriousBusiness
	{
		/// <summary>
		/// Process some business objects.
		/// </summary>
		/// <param name="objectsGuid">
		/// Objects' group identifier.
		/// </param>
		Task ProcessObjectsAsync(Guid objectsGuid);
	}
}