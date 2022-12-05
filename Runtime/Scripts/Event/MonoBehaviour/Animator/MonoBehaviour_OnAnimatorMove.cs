// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_ANIMATOR + "On Animator Move")]
	[UnityDocumentation("MonoBehaviour.OnAnimatorMove")]
	internal sealed class MonoBehaviour_OnAnimatorMove : OnEvent
	{
		private void OnAnimatorMove() => Invoke();
	}
}