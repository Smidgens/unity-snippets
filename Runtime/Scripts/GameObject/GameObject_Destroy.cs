// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Destroy")]
	[UnityDocumentation("Object.Destroy")]
	internal sealed class GameObject_Destroy : Snippet
	{
		public GameObject Object { get => _object; set => _object = value; }

		public void Invoke()
		{
			if (!_object) { return; }
			Destroy(_object);
		}
		[SerializeField] private GameObject _object = default;
	}
}