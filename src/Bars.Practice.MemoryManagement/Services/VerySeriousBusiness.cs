using System.Threading.Tasks;

namespace Bars.Practice.MemoryManagement.Services
{
	/// <inheritdoc />
	internal class VerySeriousBusiness  : IVerySeriousBusiness
	{
		/// <inheritdoc />
		Task IVerySeriousBusiness.DoItAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}