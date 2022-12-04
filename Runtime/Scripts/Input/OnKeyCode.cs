// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnKeyCode : MonoBehaviour
	{
		public void Poll()
		{
			if (!IsActive(_key)) { return; }
			Invoke();
		}

		protected abstract bool IsActive(KeyCode key);

		[SerializeField] private KeyCode _key = KeyCode.None;
		[SerializeField] private UnityEvent _onEvent = null;

		private void Invoke() => _onEvent.Invoke();

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnKeyCode), true)]
	internal sealed class _Input_KeyCode : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_input, GUIContent.none);
			EditorGUILayout.PropertyField(_onInput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onInput = null, _input = null;

		private void OnEnable()
		{
			_input = serializedObject.FindProperty("_key");
			_onInput = serializedObject.FindProperty("_onEvent");
		}
	}
}
#endif