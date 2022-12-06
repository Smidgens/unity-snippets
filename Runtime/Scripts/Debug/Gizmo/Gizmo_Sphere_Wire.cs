// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Wire Sphere")]
	[UnityDocumentation("Gizmos.DrawWireSphere")]
	internal sealed class Gizmo_Sphere_Wire : Gizmo_Sphere
	{
		protected override System.Action<Vector3, float> GetDrawFn()
		{
			return Gizmos.DrawWireSphere;
		}

	}
}