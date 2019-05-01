namespace Smidgenomics.Control
{
	using UnityEngine;

	[DisallowMultipleComponent]
	[AddComponentMenu("Smidgenomics/Control/Dont Destroy On Load")]
	internal class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake()
		{
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(DontDestroyOnLoad))]
	internal class Editor_DontDestroyOnLoad : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Object won't be destroyed on load.", MessageType.Info);
		}
	}
}
#endif