using System;

namespace Bars.Practice.MemoryManagement.Entities
{
	/// <summary>
	/// Some abstract business entity.
	/// </summary>
	internal class BizObject
	{
		private BizObject()
		{
		}

		/// <summary>
		/// Object identifier.
		/// </summary>
		public long Id { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public Guid GroupId { get; private set; }

		/// <summary>
		/// Object's description.
		/// </summary>
		public string? Description { get; private set; }

		/// <inheritdoc />
		public override string ToString()
			=> $"{nameof(Id)}: {Id}; " +
			   $"{nameof(GroupId)}: {GroupId}; " +
			   $"{nameof(Description)}: {Description}";
	}
}