// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using System.Diagnostics;

	/// <summary>
	/// Resolve link to Unity documentation page
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	internal abstract class OnlineDocumentationAttribute : Attribute
	{
		public abstract string URL { get; }
		public abstract string Label { get; }

		protected static string FormatPage(string url, string page)
		{
			return string.Format(url, page);
		}
	}
}