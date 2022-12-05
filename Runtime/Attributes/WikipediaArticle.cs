// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	// formats link to page in Unity docs
	internal sealed class WikipediaArticleAttribute : OnlineDocumentationAttribute
	{
		public override string URL { get; }
		public override string Label => Constants.Docs.LABEL_WIKIPEDIA;

		public WikipediaArticleAttribute(string page)
		{
			URL = FormatPage(Constants.Docs.URL_WIKIPEDIA, page);
		}

	}
}