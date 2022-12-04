// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis 2D")]
	internal sealed class Input_GetAxis2D : MonoBehaviour
	{
		public void Poll() => _onOutput.Invoke(GetAxis2D());

		[SerializeField] internal string _xAxis = "";
		[SerializeField] internal string _yAxis = "";
		[SerializeField] internal UnityEvent<Vector2> _onOutput = null;

		private Vector2 GetAxis2D() => new Vector2(Input.GetAxis(_xAxis), Input.GetAxis(_yAxis));

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Input_GetAxis2D), true)]
	internal sealed class _Input_GetAxis2D : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_xAxis);
			EditorGUILayout.PropertyField(_yAxis);
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _xAxis = null;
		private SerializedProperty _yAxis = null;
		private SerializedProperty _onOutput = null;

		private void OnEnable()
		{
			_xAxis = serializedObject.FindProperty(nameof(Input_GetAxis2D._xAxis));
			_yAxis = serializedObject.FindProperty(nameof(Input_GetAxis2D._yAxis));
			_onOutput = serializedObject.FindProperty(nameof(Input_GetAxis2D._onOutput));
		}
	}
}
#endif