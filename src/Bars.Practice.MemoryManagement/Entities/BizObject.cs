using System;

namespace Bars.Practice.MemoryManagement.Entities
{
	/// <summary>
	/// Some abstract business entity.
	/// </summary>
	internal class BizObject
	{
		public BizObject(long id, Guid groupId, string description)
		{
			Id = id;
			GroupId = groupId;
			Description = description;
		}

		/// <summary>
		/// Object identifier.
		/// </summary>
		public long Id { get; }

		/// <summary>
		/// 
		/// </summary>
		public Guid GroupId { get; }

		/// <summary>
		/// Object's description.
		/// </summary>
		public string Description { get; }

		/// <inheritdoc />
		public override string ToString()
			=> $"{nameof(Id)}: {Id}; " +
			   $"{nameof(GroupId)}: {GroupId}; " +
			   $"{nameof(Description)}: {Description}";
	}
}