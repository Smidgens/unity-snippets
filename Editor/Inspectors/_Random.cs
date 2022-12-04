// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
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


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random_Poisson))]
	internal sealed class _Random_Poisson : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_areaSize);
			EditorGUILayout.PropertyField(_radius);
			EditorGUILayout.PropertyField(_rejectionSamples);

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _areaSize = null;
		private SerializedProperty _radius = null;
		private SerializedProperty _rejectionSamples = null;
		private SerializedProperty _onOutput = null;

		private void OnEnable()
		{
			_areaSize = serializedObject.FindProperty("_areaSize");
			_radius = serializedObject.FindProperty("_radius");
			_rejectionSamples = serializedObject.FindProperty("_rejectionSamples");
			_onOutput = serializedObject.FindProperty("_onOutput");

		}
	}
}
#endif

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random_Perlin))]
	internal class _Random_Perlin : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onOutput = null;

		private void OnEnable()
		{
			_onOutput = serializedObject.FindProperty(nameof(Random_Perlin._onOutput));
		}
	}
}
#endif