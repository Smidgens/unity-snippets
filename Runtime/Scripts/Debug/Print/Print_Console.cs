// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	
	/// <summary>
	/// Prints messages to console, stripped in production
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_PRINT + "Console")]
	internal sealed class Print_Console : MonoBehaviour
	{
		public void Log(object v) => Log<object>(v);
		public void Log(string v) => Log<string>(v);
		public void Log(float v) => Log<float>(v);
		public void Log(int v) => Log<int>(v);
		public void Log(bool v) { Log<bool>(v); }
		public void Log(double v) => Log<double>(v);
		public void Log(Vector2 v) => Log<Vector2>(v);
		public void Log(Vector3 v) => Log<Vector3>(v);

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private static void Log<T>(in T v) => print(v);
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Print_Console))]
	internal sealed class _Print : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox(_MSG, MessageType.Info);
		}
		private const string _MSG = "Logs debug text";
	}
}
#endif