// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Base class for looping through values
	/// </summary>
	internal abstract class ForEach<T> : MonoBehaviour
	{
		public void Invoke(T[] arr)
		{
			// why bother if empty
			if(_onEach.GetPersistentEventCount() == 0) { return; }

			for (int i = 0; i < arr.Length; i++)
			{
				_onEach.Invoke(arr[i]);
			}
		}

		[SerializeField] internal UnityEvent<T> _onEach = null;
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ForEach<>), true)]
	internal sealed class _ForEach : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_onEach);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onEach = null;

		private void OnEnable()
		{
			_onEach = serializedObject.FindProperty(nameof(ForEach<int>._onEach));
		}
	}
}
#endif