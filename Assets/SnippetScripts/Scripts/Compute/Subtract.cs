namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Subtract")]
	internal class Subtract : MonoBehaviour
	{
		public void Invoke(float a)
		{
			_receivers.Invoke(_order == 0 ? _value - a : a - _value);
		}

		private enum Order { FromValue, ValueFrom }
		[System.Serializable] private class ValueEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private float _value = 0f;
		[SerializeField] private Order _order = 0;
		[SerializeField] private ValueEvent _receivers = null;
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Subtract))]
	internal class Editor_Subtract : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_value);
			EditorGUILayout.PropertyField(_order);
			EditorGUILayout.PropertyField(_receivers);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _value = null;
		private SerializedProperty _order = null;
		private SerializedProperty _receivers = null;

		private void OnEnable()
		{
			_order = serializedObject.FindProperty("_order");
			_value = serializedObject.FindProperty("_value");
			_receivers = serializedObject.FindProperty("_receivers");
		}
	}
}
#endif
