// smidgens @ github

#if SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.ASSETBUNDLE + "Load")]
	internal class AssetBundle_Load : MonoBehaviour
	{
		public void Load()
		{
			DoLoad();
		}

		public static AssetBundle LoadBundle(string bundleURI)
		{
			string rootPath = Application.dataPath;
			if(Application.isEditor) { rootPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6); }
			string fullPath = Path.Combine(rootPath, bundleURI);
			return AssetBundle.LoadFromFile(fullPath);
		}

		[SerializeField] internal string _URI = "";
		[SerializeField] internal UnityEvent<AssetBundle> _onOutput = null;

		private void DoLoad()
		{
			_onOutput.Invoke(LoadBundle(_URI));
		}
	}
}

#endif