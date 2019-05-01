namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Control/For Each String")]
	internal class ForEachString : MonoBehaviour
	{
		public void Invoke(string[] arr)
		{
			for(int i = 0; i < arr.Length; i++)
			{
				_onValue.Invoke(arr[i]);
			}
		}

		[System.Serializable] private class StringEvent : UnityEvent<string>{}
		[SerializeField] private StringEvent _onValue = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ForEachString))]
	internal class Editor_ForEachString : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onValue);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onValue = null;

		private void OnEnable()
		{
			_onValue = serializedObject.FindProperty("_onValue");
		}
	}
}
#endif