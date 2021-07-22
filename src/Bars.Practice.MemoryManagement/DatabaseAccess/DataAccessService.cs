using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
		async ValueTask<IEnumerable<BizObject>> IDataAccessService.LoadAsync(Guid groupId)
		{
			if (cache.TryGetValue(new CacheKey(groupId), out var bizObjects))
			{
				return bizObjects;
			}

			var loaded = await dbConnection.QueryAsync<BizObject>("select * from todo");

			var res = loaded
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