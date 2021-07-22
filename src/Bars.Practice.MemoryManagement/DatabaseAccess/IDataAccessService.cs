using System;
using System.Collections.Generic;
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
		IEnumerable<BizObject> Load(Guid groupId);
	}
}