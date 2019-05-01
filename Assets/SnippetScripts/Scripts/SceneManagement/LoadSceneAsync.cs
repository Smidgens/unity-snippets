namespace Smidgenomics.SceneManagement
{
	using UnityEngine;
	using System.Collections;
	using UnityEngine.SceneManagement;

	[AddComponentMenu("Smidgenomics/Scene Management/Load Scene Async")]
	public class LoadSceneAsync : MonoBehaviour
	{
		[Tooltip("If reload is disabled, load is disabled for active scene.")]
		public bool reloadActiveScene = true;

		public void LoadSingle(int index) { Load(index, LoadSceneMode.Single); }
		public void LoadAdditive(int index) { Load(index, LoadSceneMode.Additive); }

		[SerializeField] private int _priority = 0;
		[SerializeField] private bool _allowSceneActivation = true;
		[SerializeField] private SceneEvent _onLoadedScene = null;
		[SerializeField] private SceneIndexEvent _onLoadedSceneIndex = null;
		[SerializeField] private ProgressEvent _onProgress = null;
		
		[System.Serializable] private class SceneEvent : UnityEngine.Events.UnityEvent<Scene>{}
		[System.Serializable] private class SceneIndexEvent : UnityEngine.Events.UnityEvent<int>{}
		[System.Serializable] private class ProgressEvent : UnityEngine.Events.UnityEvent<float>{}

		private AsyncOperation _currentRequest = null;

		private int Current(){ return SceneManager.GetActiveScene().buildIndex; }

		public void Load(int index, LoadSceneMode mode)
		{
			var request = SceneManager.LoadSceneAsync(index, mode);
			if(!_allowSceneActivation) { _currentRequest = request; }

			request.priority = _priority;
			request.allowSceneActivation = _allowSceneActivation;
			request.completed += op =>
			{
				_onLoadedScene.Invoke(SceneManager.GetSceneByBuildIndex(index));
				_onLoadedSceneIndex.Invoke(index);
			};
			StartCoroutine(ProgressRoutine(request));
		}

		public void ActivateScene()
		{
			Debug.Log("Eh");
			if(_currentRequest == null) { return; }
			var r = _currentRequest;
			_currentRequest = null;
			r.allowSceneActivation = true;
		}

		private IEnumerator ProgressRoutine(AsyncOperation request)
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


#if UNITY_EDITOR
namespace Smidgenomics.SceneManagement
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadSceneAsync))]
	internal class Editor_LoadSceneAsync : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			string[] tabs = new string[]{ 
				string.Format("Scene ({0})", _onLoadedSceneCount.arraySize),
				string.Format("Index ({0})", _onLoadedSceneIndexCount.arraySize),
				string.Format("Progress ({0})", _onProgressCount.arraySize)
			};

			EditorGUILayout.PropertyField(_priority);
			EditorGUILayout.PropertyField(_allowSceneActivation);
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onSceneLoaded; break;
				case 1: p = _onSceneIndexLoaded; break;
				case 2: p = _onProgress; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onSceneLoaded = null;
		private SerializedProperty _onSceneIndexLoaded = null;
		private SerializedProperty _onProgress = null;
		private SerializedProperty _priority = null;
		private SerializedProperty _allowSceneActivation = null;
		private SerializedProperty _onProgressCount = null, _onLoadedSceneCount = null, _onLoadedSceneIndexCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_priority = serializedObject.FindProperty("_priority");
			_allowSceneActivation = serializedObject.FindProperty("_allowSceneActivation");
			_onSceneLoaded = serializedObject.FindProperty("_onLoadedScene");
			_onSceneIndexLoaded = serializedObject.FindProperty("_onLoadedSceneIndex");
			_onProgress = serializedObject.FindProperty("_onProgress");
			_onProgressCount = serializedObject.FindProperty("_onProgress.m_PersistentCalls.m_Calls");
			_onLoadedSceneCount = serializedObject.FindProperty("_onLoadedScene.m_PersistentCalls.m_Calls");
			_onLoadedSceneIndexCount = serializedObject.FindProperty("_onLoadedSceneIndex.m_PersistentCalls.m_Calls");
		}
	}
}
#endif