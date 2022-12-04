// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.EVENT_SCENE + "On Scene Changed")]
	internal sealed class SceneManager_activeSceneChanged : OnEvent<Scene,Scene>
	{
		private void OnEnable() => SceneManager.activeSceneChanged += OnSceneChanged;

		private void OnDisable() => SceneManager.activeSceneChanged -= OnSceneChanged;

		private void OnSceneChanged(Scene s1, Scene s2) => Invoke(s1, s2);
	}
}