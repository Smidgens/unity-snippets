// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;
	using UnityEngine.SceneManagement;

	[AddComponentMenu("Smidgenomics/Snippets/Scene/Scene : Load at Index Async")]
	internal sealed class LoadSceneAsync_BuildIndex : MonoBehaviour
	{
		public void Invoke()
		{
			if(_currentRequest != null)
			{
				return;
			}

			AsyncOperation request = SceneManager.LoadSceneAsync(_index, _mode);

			request.priority = _priority;
			request.allowSceneActivation = true;
			request.completed += op =>
			{
				_onSceneLoaded.Invoke(SceneManager.GetSceneByBuildIndex(_index));
			};
			StartCoroutine(ProgressRoutine(request));
		}


		[SerializeField] private int _index = -1;
		[SerializeField] private int _priority = 0;
		[SerializeField] private UnityEvent<Scene> _onSceneLoaded = null;
		[SerializeField] private UnityEvent<float> _onLoadingProgress = null;
		[SerializeField] private LoadSceneMode _mode = LoadSceneMode.Single;

		private AsyncOperation _currentRequest = null;

	

		public void ActivateScene()
		{
			if(_currentRequest == null) { return; }
			var r = _currentRequest;
			_currentRequest = null;
			r.allowSceneActivation = true;
		}

		private IEnumerator ProgressRoutine(AsyncOperation request)
		{
			while(!request.isDone)
			{
				_onLoadingProgress.Invoke(request.progress);
				yield return null;
			}
			_onLoadingProgress.Invoke(1f);
		}
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadSceneAsync_BuildIndex))]
	internal sealed class _LoadSceneAsync : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			string[] tabs = new string[]{ 
				string.Format("Progress ({0})", _onProgressCount.arraySize),
				string.Format("Loaded ({0})", _onLoadedSceneCount.arraySize),
			};

			EditorGUILayout.PropertyField(_index);
			EditorGUILayout.PropertyField(_mode);
			EditorGUILayout.PropertyField(_priority);
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onProgress; break;
				case 1: p = _onSceneLoaded; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onSceneLoaded = null;
		private SerializedProperty _onProgress = null;
		private SerializedProperty _priority = null;
		private SerializedProperty _index = null;
		private SerializedProperty _mode = null;
		private SerializedProperty _onProgressCount = null, _onLoadedSceneCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_priority = serializedObject.FindProperty("_priority");
			_index = serializedObject.FindProperty("_index");
			_mode = serializedObject.FindProperty("_mode");
			_onSceneLoaded = serializedObject.FindProperty("_onSceneLoaded");
			_onProgress = serializedObject.FindProperty("_onLoadingProgress");
			_onProgressCount = _onProgress.FindPersistentCalls();
			_onLoadedSceneCount = _onSceneLoaded.FindPersistentCalls();
		}
	}
}
#endif