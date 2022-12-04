// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLISION + "On Collision Exit")]
	internal sealed class Collider_OnCollisionExit : OnCollisionEvent
	{
		private void OnCollisionExit(Collision c) => Invoke(c);
	}
}
