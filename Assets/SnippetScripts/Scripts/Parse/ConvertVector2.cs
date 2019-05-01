namespace Smidgenomics.Parse
{
	using System;
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Parse/Convert Vector2")]
	internal class ConvertVector2 : MonoBehaviour
	{
		public void Invoke(Vector2 value)
		{
			_onResult.Invoke(_axisConversion == AxisConversion.Y2Y ? new Vector3(value.x, value.y, 0) : new Vector3(value.x, 0, value.y));
		}

		private enum AxisConversion { Y2Y, Y2Z }

		[Serializable] private class ResultEvent : UnityEngine.Events.UnityEvent<Vector3>{}
		[SerializeField] private AxisConversion _axisConversion = AxisConversion.Y2Y;
		[SerializeField] private ResultEvent _onResult = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Parse
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ConvertVector2))]
	internal class Editor_ConvertVector2 : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_axisConversion);
			EditorGUILayout.PropertyField(_onResult);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _axisConversion = null;
		private SerializedProperty _onResult = null;

		private void OnEnable()
		{
			_axisConversion = serializedObject.FindProperty("_axisConversion");
			_onResult = serializedObject.FindProperty("_onResult");
		}
	}
}
#endif