using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using Bars.Homework.MemoryManagement.Entities;
using Dapper;

namespace Bars.Homework.MemoryManagement.DatabaseAccess
{
	/// <inheritdoc />
	internal class DataAccessService : IDataAccessService
	{
		private static readonly ConcurrentDictionary<
			CacheKey,
			IReadOnlyCollection<BizObject>> cache = new();

		private readonly IDbConnection dbConnection;

		public DataAccessService(IDbConnection dbConnection) => this.dbConnection = dbConnection;

		/// <inheritdoc />
		IEnumerable<BizObject> IDataAccessService.Load(Guid groupId)
		{
			if (cache.TryGetValue(new CacheKey(groupId), out var bizObjects))
			{
				return bizObjects;
			}
			
			var res = dbConnection.Query<BizObject>("select * from ")
		}

		private class CacheKey
		{
			public CacheKey(Guid groupId) => GroupId = groupId;

			public Guid GroupId { get; }
		}
	}
}