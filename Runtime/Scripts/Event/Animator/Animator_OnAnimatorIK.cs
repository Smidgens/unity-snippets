// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ANIMATOR + "On Animator IK")]
	internal sealed class Animator_OnAnimatorIK : OnEvent<int>
	{
		private void OnAnimatorIK(int layerIndex) => Invoke(layerIndex);
	}
}