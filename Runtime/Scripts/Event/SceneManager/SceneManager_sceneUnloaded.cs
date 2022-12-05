// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.EVENT_ON_SCENE + "On Scene Unloaded")]
	[UnityDocumentation("SceneManagement.SceneManager-sceneUnloaded")]
	internal sealed class SceneManager_sceneUnloaded : OnEvent<Scene>
	{
		private void OnEnable() => SceneManager.sceneUnloaded += OnSceneLoaded;

		private void OnDisable() => SceneManager.sceneUnloaded -= OnSceneLoaded;

		private void OnSceneLoaded(Scene scene) => Invoke(scene);
	}
}