// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[DisallowMultipleComponent]
	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Don't Destroy")]
	[UnityDocumentation("Object.DontDestroyOnLoad")]
	internal sealed class GameObject_DontDestroy : Snippet
	{
		private void Awake() => DontDestroyOnLoad(gameObject);
	}
}