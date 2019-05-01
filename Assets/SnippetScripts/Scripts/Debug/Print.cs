namespace Smidgenomics.Debug
{
	using UnityEngine;
	[AddComponentMenu("Smidgenomics/Debug/Print")]
	internal class Print : MonoBehaviour
	{
		public void Log(string v) { Debug.Log(v); }
		public void Log(float v) { Debug.Log(v); }
		public void Log(int v) { Debug.Log(v); }
		public void Log(bool v) { Debug.Log(v); }
		public void Log(double v) { Debug.Log(v); }
		public void Log(Vector2 v) { Debug.Log(v); }
		public void Log(Vector3 v) { Debug.Log(v); }
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Debug
{
	using UnityEngine;
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Print))]
	internal class Editor_Print : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox("Logs debug text.", MessageType.Info);
			// EditorGUILayout.Space();
		}
	}
}
#endif