// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_FLOAT + "Get Float")]
	[UnityDocumentation("PlayerPrefs.GetFloat")]
	internal sealed class PlayerPrefs_Get_Float : PlayerPrefs_Get<float>
	{
		protected override Getter GetGetter() => PlayerPrefs.GetFloat;
	}
}