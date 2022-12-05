// smidgens @ github

#if SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.ASSETBUNDLE + "Load From File")]
	[UnityDocumentation("AssetBundle.LoadFromFile")]
	internal sealed class AssetBundle_LoadFromFile : MonoBehaviour
	{
		public void In() => DoLoad();

		[SerializeField] internal WrappedValue_String _path = new WrappedValue_String("");
		[SerializeField] internal UnityEvent<AssetBundle> _out = null;

		private void DoLoad()
		{
			AssetBundle ab = AssetBundle.LoadFromFile(_path);
			_out.Invoke(ab);
		}
	}
}

#endif

#if UNITY_EDITOR && SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(AssetBundle_LoadFromFile))]
	internal sealed class _LoadAssetBundle : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(AssetBundle_LoadFromFile._path),
			null,
			nameof(AssetBundle_LoadFromFile._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif