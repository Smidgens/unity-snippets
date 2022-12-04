// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_COLLISION + "On Collision Enter")]
	internal sealed class Collider_OnCollisionEnter : OnCollisionEvent
	{
		private void OnCollisionEnter(Collision c) => Invoke(c);
	}
}
