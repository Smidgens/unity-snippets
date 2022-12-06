// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.APPLICATION + "Quit")]
	[UnityDocumentation("Application.Quit")]
	internal sealed class Application_Quit : Snippet
	{
		public void In() => UnityApp.Quit();
	}
}