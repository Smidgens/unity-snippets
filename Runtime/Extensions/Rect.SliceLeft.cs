// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	internal static partial class Rect_
	{
		public static Rect SliceLeft(this ref Rect r, in float w)
		{
			Rect leftRect = r;
			leftRect.width = w;
			r.width -= w;
			r.x += w;
			return leftRect;
		}
	}
}