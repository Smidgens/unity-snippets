//namespace Smidgenomics.Unity.Snippets
//{
//	using UnityEngine;
//	using UnityEngine.Events;

//	internal abstract class OnInput<TIn> : MonoBehaviour
//	{
//		public void Input() => _onOutput.Invoke(Read());
//		protected abstract TIn Read();

//		[SerializeField] internal UnityEvent<TOut> _onOutput = null;
//	}
//}


//#if UNITY_EDITOR

//namespace Smidgenomics.Unity.Snippets.Editor
//{
//	using UnityEditor;

//	[CanEditMultipleObjects]
//	[CustomEditor(typeof(OnOutput<>), true)]
//	internal sealed class _OnOutput : Editor
//	{
//		public override void OnInspectorGUI()
//		{
//			serializedObject.UpdateIfRequiredOrScript();
//			EditorGUILayout.Space();
//			EditorGUILayout.PropertyField(_onOutput);
//			serializedObject.ApplyModifiedProperties();
//		}

//		private SerializedProperty _onOutput = null;

//		private void OnEnable()
//		{
//			_onOutput = serializedObject.FindProperty(nameof(OnOutput<float>._onOutput));
//		}
//	}
//}
//#endif