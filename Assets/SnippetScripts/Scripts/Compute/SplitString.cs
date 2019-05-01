namespace Smidgenomics.Compute
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Compute/Split String")]
	internal class SplitString : MonoBehaviour
	{
		public void Split(string text)
		{
			_onResult.Invoke(text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
		}

		[Serializable] private class ResultEvent : UnityEvent<string[]> {}
		[SerializeField] private ResultEvent _onResult = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Compute
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(SplitString))]
	internal class Editor_SplitString : Editor
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