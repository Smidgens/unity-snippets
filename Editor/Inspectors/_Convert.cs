// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Convert<,>), true)]
	internal class _Convert : Editor
	{
		public sealed override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			string[] tabs = new string[]{
				string.Format("Success ({0})", _onParsedCount.arraySize),
				string.Format("Error ({0})", _onErrorCount.arraySize)
			};
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch (_activeTab)
			{
				case 0: p = _onParsed; break;
				case 1: p = _onError; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private int _activeTab = 0;
		private SerializedProperty _onParsed = null, _onError = null;
		private SerializedProperty _onParsedCount = null, _onErrorCount = null;

		private void OnEnable()
		{
			_onParsed = serializedObject.FindProperty("_onResult");
			_onError = serializedObject.FindProperty("_onError");
			_onParsedCount = _onParsed.FindPersistentCalls();
			_onErrorCount = _onError.FindPersistentCalls();
		}
	}
}
#endif