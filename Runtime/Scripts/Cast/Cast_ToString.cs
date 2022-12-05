// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.CAST + "Value/To String")]
	internal class Cast_ToString : MonoBehaviour
	{
		public void In(object v) { Out(v); }
		public void In(float v) { Out(v); }
		public void In(int v) { Out(v); }
		public void In(bool v) { Out(v); }
		public void In(Vector3 v) { Out(v); }

		[SerializeField] internal UnityEvent<string> _out = null;

		private void Out<T>(T v) => _out.Invoke(v.ToString());
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Cast_ToString))]
	internal sealed class _ToString : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onOutput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onOutput = null;

		private void OnEnable() => _onOutput = serializedObject.FindProperty(nameof(Cast_ToString._out));
	}
}
#endif