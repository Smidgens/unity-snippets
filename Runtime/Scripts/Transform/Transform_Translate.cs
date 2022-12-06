// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Translate")]
	internal sealed class Transform_Translate : Snippet
	{
		public void AddLocalY(float t)
		{
			Vector3 pos = transform.localPosition;
			pos.y += t;
			transform.localPosition = pos;
		}

		public void SetLocalY(float v)
		{
			Vector3 pos = transform.localPosition;
			pos.y = v;
			transform.localPosition = pos;
		}

	}
}