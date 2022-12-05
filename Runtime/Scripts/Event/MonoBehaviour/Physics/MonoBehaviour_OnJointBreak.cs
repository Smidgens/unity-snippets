// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_ON_PHYSICS + "On Joint Break")]
	[UnityDocumentation("MonoBehaviour.OnJointBreak")]
	internal sealed class MonoBehaviour_OnJointBreak : OnEvent<float>
	{
		private void OnJointBreak(float breakForce) => Invoke(breakForce);
	}
}