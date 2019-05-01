namespace Smidgenomics.Parse
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Parse/To String")]
	internal class ToString : MonoBehaviour
	{
		public void Invoke(object v) { SendString(v); }
		public void Invoke(float v) { SendString(v); }
		public void Invoke(int v) { SendString(v); }
		public void Invoke(bool v) { SendString(v); }
		public void Invoke(Vector3 v) { SendString(v); }

		[System.Serializable] private class ParsedEvent : UnityEngine.Events.UnityEvent<string>{}
		[SerializeField] private ParsedEvent _onResult = null;

		private void SendString<T>(T v)
		{
			_onResult.Invoke(v.ToString());
		}
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Parse
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ToString))]
	internal class Editor_ToString : Editor
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