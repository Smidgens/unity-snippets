namespace Smidgenomics.Generate
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Generate/Random")]
	internal class Random : MonoBehaviour
	{
		public float Min { get { return _min; } set { _min = value; } }
		public float Max { get { return _max; } set { _max = value; } }

		public void Invoke()
		{
			_onValue.Invoke(GetValue());
		}

		public void Invoke(float basis)
		{
			_onValue.Invoke(basis + GetValue());
		}

		public void InvokePerlin(Vector2 input)
		{
			_onValue.Invoke(GetPerlin(input));
		}

		[Serializable] private class ValueEvent : UnityEvent<float>{}
		[SerializeField] private float _min = 0, _max = 1f;
		[SerializeField] private ValueEvent _onValue = null;

		private float GetValue()
		{
			return UnityEngine.Random.Range(_min, _max);
		}

		private static float GetPerlin(Vector2 input)
		{
			return Mathf.PerlinNoise(input.x, input.y);
		}
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Generate
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random))]
	internal class Editor_Random : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			var r = EditorGUILayout.GetControlRect();

			var labelRect = new Rect(r.x, r.y, EditorGUIUtility.labelWidth, r.height);
			var rangeRect = new Rect(r.x + labelRect.width, r.y, r.width - labelRect.width, r.height);
			
			var fRect = rangeRect;
			fRect.width *= 0.5f;

			var lRect = fRect;
			lRect.width = 30f;
			var vRect = fRect;
			vRect.width -= lRect.width + 1f;
			vRect.x += lRect.width;

			EditorGUI.LabelField(lRect, "Min");
			EditorGUI.PropertyField(vRect, _min, GUIContent.none);
			lRect.x += fRect.width + 1f;
			vRect.x += fRect.width + 1f;
			EditorGUI.LabelField(lRect, "Max");
			EditorGUI.PropertyField(vRect, _max, GUIContent.none);

			EditorGUI.LabelField(labelRect, "Range");
			EditorGUILayout.PropertyField(_onValue);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _min = null;
		private SerializedProperty _max = null;
		private SerializedProperty _onValue = null;

		private void OnEnable()
		{
			_min = serializedObject.FindProperty("_min");
			_max = serializedObject.FindProperty("_max");
			_onValue = serializedObject.FindProperty("_onValue");
		}
	}
}
#endif