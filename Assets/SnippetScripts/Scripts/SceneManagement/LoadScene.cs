namespace Smidgenomics.SceneManagement
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu("Smidgenomics/Scene Management/Load Scene")]
	public class LoadScene : MonoBehaviour
	{
		[Tooltip("If reload is disabled, load is disabled for active scene.")]
		public bool reloadActiveScene = true;

		public void LoadSingle(int index)
		{
			int c = Current();
			if(index == c && !reloadActiveScene){ return; } 
			SceneManager.LoadScene(index, LoadSceneMode.Single);
		}
		public void LoadAdditive(int index)
		{
			int c = Current();
			if(index == c && !reloadActiveScene){ return; }
			SceneManager.LoadScene(index, LoadSceneMode.Additive);
		}

		private int Current(){ return SceneManager.GetActiveScene().buildIndex; }
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.SceneManagement
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadScene))]
	internal class Editor_LoadScene : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_reloadActiveScene);
			serializedObject.ApplyModifiedProperties();
			EditorGUILayout.HelpBox("Call load methods from script.", MessageType.Info);
		}

		private SerializedProperty _reloadActiveScene = null;
		private void OnEnable()
		{
			_reloadActiveScene = serializedObject.FindProperty("reloadActiveScene");
		}
	}
}
#endif