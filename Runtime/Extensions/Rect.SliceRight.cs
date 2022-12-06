// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	internal static partial class Rect_
	{
		public static Rect SliceRight(this ref Rect r, in float w)
		{
			Rect r2 = r;
			r2.width = w;
			r.width -= w;
			r2.x += r.width;
			return r2;
		}
	}
}