namespace Smidgenomics.Generate
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Generate/Unity Time")]
	internal class UnityTime : MonoBehaviour
	{
		public void SendTotal()
		{
			_receivers.Invoke(Time.time);
		}

		public void SendDelta()
		{
			_receivers.Invoke(Time.deltaTime);
		}

		[System.Serializable] private class ValueEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private ValueEvent _receivers = null;
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Generate
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(UnityTime))]
	internal class Editor_UnityTime : Editor
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