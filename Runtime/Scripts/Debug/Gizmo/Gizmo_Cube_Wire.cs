// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Wire Cube")]
	[UnityDocumentation("Gizmos.DrawWireCube")]
	internal sealed class Gizmo_Cube_Wire : Gizmo_Cube
	{
		protected override DrawFn GetDrawFn() => Gizmos.DrawWireCube;
	}
}