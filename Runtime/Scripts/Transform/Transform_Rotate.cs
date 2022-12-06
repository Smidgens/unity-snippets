// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Rotate")]
	internal class Transform_Rotate : Snippet
	{
		public void Tick(Vector3 rot)
		{
			transform.localRotation *= Quaternion.Euler(rot);
		}
	}
}