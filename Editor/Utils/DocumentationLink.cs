// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using System;
	using System.Reflection;

	/// <summary>
	/// Display documentation info and help for script
	/// </summary>
	internal sealed class DocumentationHeader
	{
		public void DrawLayout()
		{
			if(_page == null) { return; }
			EGUI.Link(GetLabel(), _page.URL);
		}

		public DocumentationHeader(Type type)
		{
			_page = FindAttribute<OnlineDocumentationAttribute>(type);
		}

		private GUIContent GetLabel()
		{
			if(_label == null)
			{
				_label = new GUIContent(_page.Label, _page.URL);
			}
			return _label;
		}

		private GUIContent _label = null;
		private OnlineDocumentationAttribute _page = null;
		private static T FindAttribute<T>(Type t) where T : Attribute => t.GetCustomAttribute<T>();

	}
}

#endif