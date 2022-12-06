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

		[SerializeField] internal Wrapped_String _path = new Wrapped_String("");
		[SerializeField] internal UnityEvent<AssetBundle> _out = null;

		private void DoLoad()
		{
			AssetBundle ab = AssetBundle.LoadFromFile(_path);
			_out.Invoke(ab);
		}
	}
}

#endif