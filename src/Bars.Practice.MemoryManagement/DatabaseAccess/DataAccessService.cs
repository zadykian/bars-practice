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

		public DataAccessService(
			IMigrator migrator,
			IDbConnection dbConnection)
		{
			migrator.CreateSchema();
			this.dbConnection = dbConnection;
		}

		/// <inheritdoc />
		async ValueTask<IEnumerable<BizObject>> IDataAccessService.LoadAsync(Guid groupId)
		{
			if (cache.TryGetValue(new CacheKey(groupId), out var bizObjects))
			{
				return bizObjects;
			}

			var loaded = await dbConnection
				.QueryAsync<BizObject>($@"
					select
						id          as ""{nameof(BizObject.Id)}"",
						group_id    as ""{nameof(BizObject.GroupId)}"",
						description as ""{nameof(BizObject.Description)}"",
					from memory_management_practice.biz_objects");

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