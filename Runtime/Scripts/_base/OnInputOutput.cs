namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnInputOutput<TIn, TOut> : MonoBehaviour
	{
		public void Input(TIn v) => _onOutput.Invoke(Compute(v));
		protected abstract TOut Compute(in TIn v);

		[SerializeField] internal UnityEvent<TOut> _onOutput = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnInputOutput<,>), true)]
	internal sealed class _OnInputOutput : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onResult);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onResult = null;

		private void OnEnable()
		{
			_onResult = serializedObject.FindProperty(nameof(OnInputOutput<float,float>._onOutput));
		}
	}
}
#endif