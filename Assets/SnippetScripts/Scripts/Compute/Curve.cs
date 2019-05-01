namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Curve")]
	internal class Curve : MonoBehaviour
	{
		public void Invoke(float t)
		{
			_onEvent.Invoke(_curve.Evaluate(t));
		}
		[System.Serializable] private class ValueEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private AnimationCurve _curve = AnimationCurve.Linear(0, 0f, 1f, 1f);
		[SerializeField] private ValueEvent _onEvent = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Curve))]
	internal class Editor_Curve : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_curve);
			EditorGUILayout.PropertyField(_onEvent);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _curve = null;
		private SerializedProperty _onEvent = null;

		private void OnEnable()
		{
			_curve = serializedObject.FindProperty("_curve");
			_onEvent = serializedObject.FindProperty("_onEvent");
		}
	}
}
#endif