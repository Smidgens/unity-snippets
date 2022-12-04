// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_PHYSICS + "On Controller Collider Hit")]
	internal sealed class Physics_OnControllerColliderHit : OnEvent<ControllerColliderHit>
	{
		private void OnControllerColliderHit(ControllerColliderHit hit) => Invoke(hit);
	}
}