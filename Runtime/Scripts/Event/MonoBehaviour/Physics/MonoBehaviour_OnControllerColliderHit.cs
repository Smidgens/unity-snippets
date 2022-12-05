// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_PHYSICS + "On Controller Collider Hit")]
	[UnityDocumentation("MonoBehaviour.OnControllerColliderHit")]
	internal sealed class MonoBehaviour_OnControllerColliderHit : OnEvent<ControllerColliderHit>
	{
		private void OnControllerColliderHit(ControllerColliderHit hit) => Invoke(hit);
	}
}