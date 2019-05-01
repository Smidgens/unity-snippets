namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Add")]
	internal class Add : MonoBehaviour
	{
		public void Invoke(float a)
		{
			_receivers.Invoke(a + _value);
		}

		[System.Serializable] private class ValueEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private float _value = 0f;
		[SerializeField] private ValueEvent _receivers = null;
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Add))]
	internal class Editor_Add : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_value);
			EditorGUILayout.PropertyField(_receivers);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _value = null;
		private SerializedProperty _receivers = null;

		private void OnEnable()
		{
			_value = serializedObject.FindProperty("_value");
			_receivers = serializedObject.FindProperty("_receivers");
		}
	}
}
#endif
