namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Sin")]
	internal class Sin : MonoBehaviour
	{
		public void Invoke(float t)
		{
			_receivers.Invoke((float)Math.Sin(t));
		}

		[System.Serializable] private class ValueEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private ValueEvent _receivers = null;
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Sin))]
	internal class Editor_Sin : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_receivers);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _receivers = null;

		private void OnEnable()
		{
			_receivers = serializedObject.FindProperty("_receivers");
		}
	}
}
#endif