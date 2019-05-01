namespace Smidgenomics.Control
{
	using System;
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Control/Wait")]
	internal class Wait : MonoBehaviour
	{
		public void Invoke(float delay)
		{
			if(delay < 0) { return; }
			StartCoroutine(InvokeRoutine(delay));
		}

		[SerializeField] private UnityEvent _onEnd = null;

		private IEnumerator InvokeRoutine(float t)
		{
			yield return new WaitForSeconds(t);
			_onEnd.Invoke();
		}
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Wait))]
	internal class Editor_Wait : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onEnd);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onEnd = null;

		private void OnEnable()
		{
			_onEnd = serializedObject.FindProperty("_onEnd");
		}
	}
}
#endif