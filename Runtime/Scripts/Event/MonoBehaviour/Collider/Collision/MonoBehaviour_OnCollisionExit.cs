// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_COLLISION + "Exit")]
	[UnityDocumentation("MonoBehaviour.OnCollisionExit")]
	internal sealed class MonoBehaviour_OnCollisionExit : OnCollisionEvent
	{
		private void OnCollisionExit(Collision c) => Invoke(c);
	}
}
