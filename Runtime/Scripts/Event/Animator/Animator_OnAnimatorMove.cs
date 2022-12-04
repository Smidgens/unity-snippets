// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ANIMATOR + "On Animator Move")]
	internal sealed class Animator_OnAnimatorMove : OnEvent
	{
		private void OnAnimatorMove() => Invoke();
	}
}