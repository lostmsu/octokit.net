namespace Octokit
{
	using System;
	using System.Collections.Generic;
	#if NET_45
	using System.Collections.ObjectModel;
	#endif
	using System.Threading.Tasks;

	/// <summary>
	/// A client for GitHub's paged collections.
	/// </summary>
	/// <typeparam name="T">Type of an item in the collection</typeparam>
	public class PagedCollectionClient<T>: ApiClient, IPagedCollectionClient<T>
	{
		readonly Func<int, Uri> pageUriFactory;

		/// <summary>
		/// Initializes GitHub paged collection client.
		/// </summary>
		/// <param name="apiConnection">An <see cref="IApiConnection"/></param>
		/// <param name="pageUriFactory">Page URL factory</param>
		public PagedCollectionClient(IApiConnection apiConnection, Func<int, Uri> pageUriFactory) : base(apiConnection)
		{
			Ensure.ArgumentNotNull(pageUriFactory, "pageUriFactory");

			this.pageUriFactory = pageUriFactory;
		}

		/// <summary>
		/// Gets items from specified page.
		/// </summary>
		/// <param name="page">Page index</param>
		/// <returns>A <see cref="IReadOnlyList{T}"/></returns>
		public async Task<IReadOnlyList<T>> GetPage(int page)
		{
			var uri = pageUriFactory(page);

			var response = await Connection.GetAsync<List<T>>(uri, null, null).ConfigureAwait(false);
			return new ReadOnlyCollection<T>(response.BodyAsObject);
		}
	}
}
