// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Set Hide Flags")]
	[UnityDocumentation("Object-hideFlags")]
	internal sealed class GameObject_SetHideFlags : Snippet
	{
		public int Flags
		{
			get => (int)_flags;
			set => _flags = (HideFlags)value;
		}

		public void In(GameObject go) => go.hideFlags = _flags;

		[SerializeField] private HideFlags _flags = HideFlags.None;
	}
}