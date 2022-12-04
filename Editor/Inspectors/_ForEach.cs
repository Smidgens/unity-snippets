// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ForEach<>), true)]
	internal sealed class _ForEach : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onEach);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onEach = null;

		private void OnEnable()
		{
			_onEach = serializedObject.FindProperty(nameof(ForEach<int>._onEach));
		}
	}
}
#endif