namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Cos")]
	internal class Cos : MonoBehaviour
	{
		public void Invoke(float t)
		{
			_receivers.Invoke((float)Math.Cos(t));
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
	[CustomEditor(typeof(Cos))]
	internal class Editor_Cos : Editor
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
