// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS_FLOAT + "Set Float")]
	[UnityDocumentation("PlayerPrefs.SetFloat")]
	internal sealed class PlayerPrefs_Set_Float : PlayerPrefs_Set<float>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetFloat;
	}
}