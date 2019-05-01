namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Control/For Each Vector2")]
	internal class ForEachVector2 : MonoBehaviour
	{
		public void Invoke(Vector2[] arr)
		{
			for(int i = 0; i < arr.Length; i++)
			{
				_onValue.Invoke(arr[i]);
			}
		}
		[System.Serializable] private class ValueEvent : UnityEvent<Vector2>{}
		[SerializeField] private ValueEvent _onValue = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ForEachVector2))]
	internal class Editor_ForEachVector2 : Editor
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