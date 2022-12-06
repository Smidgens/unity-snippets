// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS + "Save")]
	[UnityDocumentation("PlayerPrefs.Save")]
	internal sealed class PlayerPrefs_Save : Snippet
	{
		public void In() => PlayerPrefs.Save();
	}
}