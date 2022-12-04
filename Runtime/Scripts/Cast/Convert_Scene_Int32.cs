// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.CONVERT_SCENE + "→ Int")]
	internal class Convert_Scene_Int32 : Convert<Scene, int>
	{
		protected override bool TryParse(Scene x, out int y)
		{
			y = x.buildIndex;
			return x.IsValid();
		}
	}
}