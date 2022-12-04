// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis 1D")]
	internal sealed class Input_GetAxis : MonoBehaviour
	{
		public void Poll() => _onOutput.Invoke(GetAxis());

		[SerializeField] internal string _axis = "";
		[SerializeField] internal UnityEvent<float> _onOutput = null;

		private float GetAxis() => Input.GetAxis(_axis);

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Input_GetAxis), true)]
	internal sealed class _Input_GetAxis : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_input);
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _input = null;
		private SerializedProperty _onOutput = null;

		private void OnEnable()
		{
			_input = serializedObject.FindProperty(nameof(Input_GetAxis._axis));
			_onOutput = serializedObject.FindProperty(nameof(Input_GetAxis._onOutput));
		}
	}
}
#endif