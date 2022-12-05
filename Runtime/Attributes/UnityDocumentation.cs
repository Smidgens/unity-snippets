// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	// formats link to page in Unity docs
	internal sealed class UnityDocumentationAttribute : OnlineDocumentationAttribute
	{
		public override string URL { get; }
		public override string Label => Constants.Docs.LABEL_UNITY;

		public UnityDocumentationAttribute(string page)
		{
			URL = FormatPage(Constants.Docs.URL_UNITY, page);
		}

	}
}