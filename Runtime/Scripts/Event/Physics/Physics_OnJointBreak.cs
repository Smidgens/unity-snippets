// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_PHYSICS + "On Joint Break")]
	internal sealed class Physics_OnJointBreak : OnEvent<float>
	{
		private void OnJointBreak(float breakForce) => Invoke(breakForce);
	}
}