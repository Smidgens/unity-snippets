// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu("Smidgenomics/Snippets/Scene/Scene : Load at Index")]
	internal sealed class LoadScene_BuildIndex : MonoBehaviour
	{
		[SerializeField] private int _index = -1;

		public void Invoke()
		{
			if(_index < 0) { return; }
			SceneManager.LoadScene(_index);
		}
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadScene_BuildIndex))]
	internal class _LoadScene_BuildIndex : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_index);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _index = null;
		private void OnEnable()
		{
			_index = serializedObject.FindProperty("_index");
		}
	}
}
#endif