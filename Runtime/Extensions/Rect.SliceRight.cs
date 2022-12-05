// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	public static partial class Rect_
	{
		public static Rect SliceRight(this ref Rect r, in float w)
		{
			var r2 = r;
			r2.width = w;
			r.width -= w;
			r2.x += r.width;
			return r2;
		}
	}
}