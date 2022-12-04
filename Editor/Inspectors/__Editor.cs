// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	/// <summary>
	/// Base class to render default inspector
	/// </summary>
	internal abstract class __Editor : Editor
	{
		public override sealed void OnInspectorGUI()
		{
			// todo: loop through properties
		}

		private void OnEnable()
		{
			// todo: find properties
		}
	}
}
#endif