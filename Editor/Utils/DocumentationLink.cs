// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using System;
	using System.Reflection;

	internal sealed class DocumentationLink
	{
		public void DrawAvailable()
		{
			if(_page == null) { return; }
			EIMGUI.Link(_page.Label, _page.URL);
		}

		public DocumentationLink(Type type)
		{
			_page = FindPage(type);
		}

		private OnlineDocumentationAttribute _page = null;

		private static OnlineDocumentationAttribute FindPage(Type t)
		{
			return t.GetCustomAttribute<OnlineDocumentationAttribute>();
		}
	}
}

#endif