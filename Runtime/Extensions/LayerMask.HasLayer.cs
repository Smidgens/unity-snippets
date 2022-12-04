// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	internal static partial class LayerMask_
	{
		/// <summary>
		/// Check if mask contains layer
		/// </summary>
		/// <param name="mask">LayerMask</param>
		/// <param name="layer">Layer</param>
		/// <returns>True if mask is in layer</returns>
		public static bool HasLayer(this in LayerMask mask, in int layer)
		{
			return mask == (mask | (1 << layer));
		}
	}
}