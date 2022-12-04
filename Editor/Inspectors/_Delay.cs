// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Delay))]
	internal class _Delay : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onExit);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty
		_onExit = null;

		private void OnEnable()
		{
			_onExit = serializedObject.FindProperty(nameof(Delay._onExit));
		}
	}
}
#endif