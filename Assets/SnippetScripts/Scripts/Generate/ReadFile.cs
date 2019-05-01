namespace Smidgenomics.Generate
{
	using System;
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Generate/Read File")]
	internal class ReadFile : MonoBehaviour
	{
		public void Read(string path)
		{
			var fullpath = path;
			if(!IsAbsoluteUrl(path))
			{
				string root = Application.dataPath;
				#if UNITY_EDITOR
				root = root.Remove(root.Length - 6);
				#endif
				fullpath = Path.Combine(root, path);
			}
			if(File.Exists(fullpath)) { _onSuccess.Invoke(File.ReadAllText(fullpath)); }
			else { _onFail.Invoke(); }
		}

		[Serializable] private class StringEvent : UnityEvent<string> {}
		[SerializeField] private StringEvent _onSuccess = null;
		[SerializeField] private UnityEvent _onFail = null;

		

		private bool IsAbsoluteUrl(string url)
		{
			Uri result;
			return Uri.TryCreate(url, UriKind.Absolute, out result);
		}


	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Generate
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ReadFile))]
	internal class Editor_ReadFile : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			string[] tabs = new string[]{ 
				string.Format("Success ({0})", _successCount.arraySize), 
				string.Format("Fail ({0})", _failCount.arraySize)
			};


			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onSuccess; break;
				case 1: p = _onFail; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onSuccess = null, _onFail = null;
		private SerializedProperty _successCount = null, _failCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_onSuccess = serializedObject.FindProperty("_onSuccess");
			_onFail = serializedObject.FindProperty("_onFail");
			_successCount = serializedObject.FindProperty("_onSuccess.m_PersistentCalls.m_Calls");
			_failCount = serializedObject.FindProperty("_onFail.m_PersistentCalls.m_Calls");
		}
	}
}
#endif