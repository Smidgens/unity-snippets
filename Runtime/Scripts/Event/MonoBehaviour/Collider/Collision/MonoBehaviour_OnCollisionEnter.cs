// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_COLLISION + "Enter")]
	[UnityDocumentation("MonoBehaviour.OnCollisionEnter")]
	internal sealed class MonoBehaviour_OnCollisionEnter : OnCollisionEvent
	{
		private void OnCollisionEnter(Collision c) => Invoke(c);
	}
}
