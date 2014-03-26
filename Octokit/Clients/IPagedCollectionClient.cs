using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit
{
	/// <summary>
	/// A client for any paged collection
	/// </summary>
	/// <typeparam name="T">Type of element in the collection</typeparam>
	/// <remarks>
	/// See <a href="http://developer.github.com/v3/#pagination">general API documentation</a> for more details.
	/// </remarks>
	public interface IPagedCollectionClient<T>
	{
		/// <summary>
		/// Gets items from specified page.
		/// </summary>
		/// <param name="page">Page index</param>
		/// <returns>A <see cref="IReadOnlyList{T}"/></returns>
		Task<IReadOnlyList<T>> GetPage(int page);
	}
}
