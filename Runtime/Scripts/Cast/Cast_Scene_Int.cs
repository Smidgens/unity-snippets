// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.CONVERT_SCENE + "→ Int")]
	[UnityDocumentation("SceneManagement.Scene-buildIndex")]
	internal class Cast_Scene_Int : Cast<Scene, int>
	{
		protected override bool TryParse(Scene x, out int y)
		{
			y = x.buildIndex;
			return x.IsValid();
		}
	}
}