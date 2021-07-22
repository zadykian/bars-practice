using System.Data;
using System.Runtime.CompilerServices;
using Dapper;

namespace Bars.Practice.MemoryManagement.DatabaseAccess
{
	/// <inheritdoc />
	internal class Migrator : IMigrator
	{
		private static bool isInitialized;
		private readonly IDbConnection dbConnection;

		public Migrator(IDbConnection dbConnection) => this.dbConnection = dbConnection;

		/// <inheritdoc />
		[MethodImpl(MethodImplOptions.Synchronized)]
		void IMigrator.CreateSchema()
		{
			if (isInitialized) return;

			dbConnection.Execute("drop schema if exists memory_management_practice cascade;");
			dbConnection.Execute("create schema memory_management_practice;");

			dbConnection.Execute(@"
				create table memory_management_practice.biz_objects
				(
					id          serial primary key,
					group_id    uuid   not null,
					description text
				)");

			dbConnection.Execute(@"
				insert into memory_management_practice.biz_objects (group_id, description)
				select
					'82433680-da5f-49c3-a116-06af6fcad5df',
					repeat(concat_ws('_', 'description', int_value), 1000)
				from generate_series(1, 1000) as int_values(int_value)");

			dbConnection.Execute(@"
				insert into memory_management_practice.biz_objects (group_id, description)
				select
					'a8656f5e-70d4-4591-8449-da63f4593986',
					repeat(concat_ws('_', 'description', int_value), 1000)
				from generate_series(1, 1000) as int_values(int_value)");

			isInitialized = true;
		}
	}
}