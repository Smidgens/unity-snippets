namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Multiply")]
	internal class Multiply : MonoBehaviour
	{
		public float Value { get { return _value; } set { _value = value; } }

		public void Invoke(float a) { _receivers.Invoke(a * _value); }

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
	[CustomEditor(typeof(Multiply))]
	internal class Editor_Multiply : Editor
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
