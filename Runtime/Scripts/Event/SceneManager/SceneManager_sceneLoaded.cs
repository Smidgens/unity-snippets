// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.EVENT_ON_SCENE + "On Scene Loaded")]
	[UnityDocumentation("SceneManagement.SceneManager-sceneLoaded")]
	internal sealed class SceneManager_sceneLoaded : OnEvent<Scene>
	{
		private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;

		private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

		private void OnSceneLoaded(Scene scene, LoadSceneMode _mode) => Invoke(scene);
	}
}