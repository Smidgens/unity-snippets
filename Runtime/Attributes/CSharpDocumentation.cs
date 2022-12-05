// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	// formats link to page in Unity docs
	internal sealed class CSharpDocumentationAttribute : OnlineDocumentationAttribute
	{
		public override string URL { get; }
		public override string Label => Constants.Docs.LABEL_CSHARP;

		public CSharpDocumentationAttribute(string page)
		{
			URL = FormatPage(Constants.Docs.URL_CSHARP, page);
		}
	}
}