#pragma warning disable 0168 // var declared, unused
#pragma warning disable 0219 // var assigned, unused
#pragma warning disable 0414 // private var assigned, unused

namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.SceneManagement;
	
	[AddComponentMenu("Smidgenomics/Event/On Unity Event")]
	[ExecuteInEditMode]
	internal class OnUnityEvent : MonoBehaviour
	{
		private enum ScriptEvent { None, Awake, Start, Update, LateUpdate, FixedUpdate, OnEnable, OnDisable, SceneLoaded, OnDestroy }
		[System.Serializable] private class SceneEvent : UnityEvent<Scene> {}
		[SerializeField] private ScriptEvent _event = ScriptEvent.None;
		[SerializeField] private UnityEvent _onEvent = null;
		[SerializeField] private SceneEvent _onSceneLoaded = null;

		#if UNITY_EDITOR
		[SerializeField] private bool _editMode = false;
		#endif
		
		private void Awake()
		{
			CheckInvoke(ScriptEvent.Awake);
		}

		private void OnEnable()
		{
			SceneManager.sceneLoaded += OnSceneLoaded;
			CheckInvoke(ScriptEvent.OnEnable);
		}

		private void OnDisable()
		{
			SceneManager.sceneLoaded -= OnSceneLoaded;
			CheckInvoke(ScriptEvent.OnDisable);
		}
		
		private void Start()
		{
			CheckInvoke(ScriptEvent.Start);
		}

		private void Update ()
		{
			CheckInvoke(ScriptEvent.Update);
		}

		private void LateUpdate()
		{
			CheckInvoke(ScriptEvent.LateUpdate);
		}

		private void FixedUpdate()
		{
			CheckInvoke(ScriptEvent.FixedUpdate);
		}

		private void OnDestroy()
		{
			CheckInvoke(ScriptEvent.OnDestroy);
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if(_event != ScriptEvent.SceneLoaded) { return; }
			_onSceneLoaded.Invoke(scene);
		}

		private void CheckInvoke(ScriptEvent e)
		{
			#if UNITY_EDITOR
			if(!Application.isPlaying && !_editMode) { return; }
			#endif
			if(_event == e) { _onEvent.Invoke(); }
		}
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Event
{

	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.SceneManagement;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnUnityEvent))]
	internal class Editor_OnUnityEvent : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			
			EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
			EditorGUILayout.PropertyField(_event, GUIContent.none);
			EditorGUILayout.PropertyField(_editMode);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.PropertyField(_event.enumValueIndex == 8 ? _onSceneLoaded : _onEvent, new GUIContent("On Event"));
			serializedObject.ApplyModifiedProperties();
		}
		
		private SerializedProperty _event = null;
		private SerializedProperty _onEvent = null;
		private SerializedProperty _onSceneLoaded = null;
		private SerializedProperty _editMode = null;

		private void OnEnable()
		{
			_event = serializedObject.FindProperty("_event");
			_onEvent = serializedObject.FindProperty("_onEvent");
			_onSceneLoaded = serializedObject.FindProperty("_onSceneLoaded");
			_editMode = serializedObject.FindProperty("_editMode");
		}
	}
	
}

#endif