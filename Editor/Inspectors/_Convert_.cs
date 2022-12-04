// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Convert_Vector2_Vector3))]
	internal class _Convert_Vector2_Vector3 : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_axisConversion);
			EditorGUILayout.PropertyField(_onResult);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _axisConversion = null;
		private SerializedProperty _onResult = null;

		private void OnEnable()
		{
			_axisConversion = serializedObject.FindProperty(nameof(Convert_Vector2_Vector3._axes));
			_onResult = serializedObject.FindProperty(nameof(Convert_Vector2_Vector3._onResult));
		}
	}
}

#endif