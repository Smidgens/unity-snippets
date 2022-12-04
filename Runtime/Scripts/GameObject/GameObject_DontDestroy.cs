// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[DisallowMultipleComponent]
	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Don't Destroy")]
	internal class GameObject_DontDestroy : MonoBehaviour
	{
		private void Awake() => DontDestroyOnLoad(gameObject);
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(GameObject_DontDestroy))]
	internal class _DontDestroyOnLoad : __BasicEditor
	{
		protected override string GetMessageText()
		{
			return "Object won't be destroyed on load.";
		}
	}
}
#endif