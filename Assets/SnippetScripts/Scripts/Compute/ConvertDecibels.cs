namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Convert Decibels")]
	internal class ConvertDecibels : MonoBehaviour
	{
		public void LinearToDecibel(float linear)
		{
			_onResult.Invoke(linear != 0 ? 20.0f * Mathf.Log10(linear) : -144.0f);
		}

		public void DecibelToLinear(float db)
		{
			_onResult.Invoke(Mathf.Pow(10.0f, db/20.0f));
		}

		[System.Serializable] private class ValueEvent : UnityEvent<float>{}
		[SerializeField] private ValueEvent _onResult = null;
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ConvertDecibels))]
	internal class Editor_ConvertDecibel : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onResult);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onResult = null;

		private void OnEnable()
		{
			_onResult = serializedObject.FindProperty("_onResult");
		}
	}
}
#endif
