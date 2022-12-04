// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;

	/// <summary>
	/// Global event bus
	/// </summary>
	internal static class CustomEvent
	{
		internal static event Action<string> onMessage = null;

		internal static void Emit(string msg) => onMessage?.Invoke(msg);
	}
}