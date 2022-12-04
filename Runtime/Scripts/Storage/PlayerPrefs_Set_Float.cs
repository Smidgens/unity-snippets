// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.STORAGE_PREFS + "Float/Player Prefs : Set Float")]
	internal sealed class PlayerPrefs_Set_Float : PlayerPrefs_Set<float>
	{
		protected override Setter GetSetter() => PlayerPrefs.SetFloat;
	}
}