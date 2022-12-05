// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_COLLISION + "Stay")]
	[UnityDocumentation("MonoBehaviour.OnCollisionStay")]
	internal sealed class MonoBehaviour_OnCollisionStay : OnCollisionEvent
	{
		private void OnCollisionStay(Collision c) => Invoke(c);
	}
}
