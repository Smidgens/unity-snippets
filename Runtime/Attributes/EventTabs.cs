// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using System.Diagnostics;

	/// <summary>
	/// UnityEvent fields should be displayed as tabs
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	[Conditional("UNITY_EDITOR")]
	internal sealed class DrawEventsAsTabsAttribute : Attribute
	{
	
	}
}


namespace Smidgenomics.Unity.Snippets
{
	using System;
	using System.Diagnostics;

	// display arrays as reorderable lists
	[AttributeUsage(AttributeTargets.Class)]
	[Conditional("UNITY_EDITOR")]
	internal sealed class DrawArraysAsListsAttribute : Attribute
	{

	}
}