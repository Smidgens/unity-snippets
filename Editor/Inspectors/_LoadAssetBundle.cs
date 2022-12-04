// smidgens @ github

#if UNITY_EDITOR && SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(AssetBundle_Load))]
	internal sealed class _LoadAssetBundle : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(AssetBundle_Load._URI),
			null,
			nameof(AssetBundle_Load._onOutput),
		};

		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif