// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLISION + "On Collision Stay")]
	internal sealed class Collider_OnCollisionStay : OnCollisionEvent
	{
		private void OnCollisionStay(Collision c) => Invoke(c);
	}
}
