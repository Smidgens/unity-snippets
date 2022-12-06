// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	// base class for all snippets, mostly to render default inspector
	internal abstract class Snippet : MonoBehaviour
	{

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Snippet), true)]
	internal sealed class _Snippet : __Inspector { }
}

#endif