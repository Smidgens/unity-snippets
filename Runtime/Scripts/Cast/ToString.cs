// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.CAST + "Value/To String")]
	internal class ToString : MonoBehaviour
	{
		public void Input(object v) { SendString(v); }
		public void Input(float v) { SendString(v); }
		public void Input(int v) { SendString(v); }
		public void Input(bool v) { SendString(v); }
		public void Input(Vector3 v) { SendString(v); }

		[SerializeField] private UnityEvent<string> _onOutput = null;

		private void SendString<T>(T v) => _onOutput.Invoke(v.ToString());
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ToString))]
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

		private void OnEnable() => _onOutput = serializedObject.FindProperty("_onOutput");
	}
}
#endif