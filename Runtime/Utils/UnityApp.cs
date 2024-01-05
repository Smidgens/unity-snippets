// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	internal static partial class UnityApp
	{
		/// <summary>
		/// Quit application
		/// </summary>
		public static void Quit()
		{
			// Application.Quit doesn't work in editor
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			UnityEngine.Application.Quit();
			#endif
		}
	}
}