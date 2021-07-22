using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using Bars.Practice.MemoryManagement.Entities;
using Dapper;

namespace Bars.Practice.MemoryManagement.DatabaseAccess
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

			var res = dbConnection
				.Query<BizObject>("select * from todo")
				.Where(bizObject => bizObject.GroupId == groupId)
				.ToImmutableArray();

			var cacheKey = new CacheKey(groupId);
			cache[cacheKey] = res;
			return res;
		}

		private class CacheKey
		{
			public CacheKey(Guid groupId) => GroupId = groupId;

			public Guid GroupId { get; }
		}
	}
}