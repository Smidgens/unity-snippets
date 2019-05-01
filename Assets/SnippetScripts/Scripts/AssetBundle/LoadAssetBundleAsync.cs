namespace Smidgenomics.AssetBundle
{
	using System;
	using System.Collections;
	using System.IO;
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Asset Bundle/Load Asset Bundle Async")]
	internal class LoadAssetBundleAsync : MonoBehaviour
	{
		public void Load()
		{
			string rootPath = Application.dataPath;
			if(Application.isEditor) { rootPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6); }
			string fullPath = Path.Combine(rootPath, _assetBundleURI);
			var request = AssetBundle.LoadFromFileAsync(fullPath);
			request.priority = _priority;
			request.completed += op =>
			{
				if(request.assetBundle != null) { _onBundleLoad.Invoke(request.assetBundle); }
			};
			StartCoroutine(ProgressRoutine(request));
		}

		[SerializeField] private int _priority = 0;
		[SerializeField] private string _assetBundleURI = "";
		[SerializeField] private BundleEvent _onBundleLoad = null;
		[SerializeField] private ProgressEvent _onProgress = null;
		[System.Serializable] private class BundleEvent : UnityEngine.Events.UnityEvent<AssetBundle>{}
		[System.Serializable] private class ProgressEvent : UnityEngine.Events.UnityEvent<float>{}

		private IEnumerator ProgressRoutine(AssetBundleCreateRequest request)
		{
			if(_onProgress.GetPersistentEventCount() > 0)
			{
				while(!request.isDone)
				{
					_onProgress.Invoke(request.progress);
					yield return null;
				}
				_onProgress.Invoke(1f);
			}
		}
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.AssetBundle
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadAssetBundleAsync))]
	internal class Editor_LoadAssetBundleAsync : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_priority);
			EditorGUILayout.PropertyField(_assetBundleURI);


			string[] tabs = new string[]{ 
				string.Format("Done ({0})", _onLoadedCount.arraySize),
				string.Format("Progress ({0})", _onProgressCount.arraySize)
			};

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onBundleLoad; break;
				case 1: p = _onProgress; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();

			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _assetBundleURI = null;
		private SerializedProperty _onBundleLoad = null;
		private SerializedProperty _priority = null;
		private SerializedProperty _onProgress = null;

		private SerializedProperty _onProgressCount = null, _onLoadedCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_assetBundleURI = serializedObject.FindProperty("_assetBundleURI");
			_onBundleLoad = serializedObject.FindProperty("_onBundleLoad");
			_onProgress = serializedObject.FindProperty("_onProgress");
			_priority = serializedObject.FindProperty("_priority");

			_onProgressCount = serializedObject.FindProperty("_onProgress.m_PersistentCalls.m_Calls");
			_onLoadedCount = serializedObject.FindProperty("_onBundleLoad.m_PersistentCalls.m_Calls");
		}
	}
}
#endif