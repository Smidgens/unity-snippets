// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_ANIMATOR + "On Animator IK")]
	[UnityDocumentation("MonoBehaviour.OnAnimatorIK")]
	internal sealed class MonoBehaviour_OnAnimatorIK : OnEvent<int>
	{
		private void OnAnimatorIK(int layerIndex) => Invoke(layerIndex);
	}
}