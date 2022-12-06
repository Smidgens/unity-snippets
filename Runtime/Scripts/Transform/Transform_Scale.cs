// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Scale")]
	internal sealed class Transform_Scale : Snippet
	{
		public void In(float scale)
		{
			transform.localScale = Vector3.one * scale;
		}

		public void Tick(Vector3 scale)
		{
			Vector3 newScale = transform.localScale;
			newScale.x *= scale.x;
			newScale.y *= scale.y;
			newScale.z *= scale.z;
			transform.localScale = newScale;
		}
	}
}