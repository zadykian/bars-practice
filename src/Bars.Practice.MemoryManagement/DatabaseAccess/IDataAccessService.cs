using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bars.Practice.MemoryManagement.Entities;

namespace Bars.Practice.MemoryManagement.DatabaseAccess
{
	/// <summary>
	/// Data access service.
	/// </summary>
	internal interface IDataAccessService
	{
		/// <summary>
		/// Load objects from data storage which belong to group with <paramref name="groupId"/>.
		/// </summary>
		/// <param name="groupId">
		/// Group identifier.
		/// </param>
		ValueTask<IEnumerable<BizObject>> LoadAsync(Guid groupId);
	}
}