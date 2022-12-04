// smidgens @ github


namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnInputOutput<TIn, TLeft, TOut> : MonoBehaviour
	{
		public void In(TIn rhs) => _onOutput.Invoke(Compute(_l, rhs));

		protected abstract TOut Compute(in TLeft lhs, in TIn rhs);

		[SerializeField] internal TLeft _l = default;
		[SerializeField] internal UnityEvent<TOut> _onOutput = null;
	}
}



#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnInputOutput<,,>), true)]
	internal sealed class _OnInputOutputMathUnary : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_value);
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _value = null;
		private SerializedProperty _onOutput = null;

		private void OnEnable()
		{
			_value = serializedObject.FindProperty(nameof(OnInputOutput<float,float,float>._l));
			_onOutput = serializedObject.FindProperty(nameof(OnInputOutput<float, float, float>._onOutput));
		}
	}
}
#endif
