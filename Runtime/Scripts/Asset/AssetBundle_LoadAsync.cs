// smidgens @ github

#if SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections;
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.ASSETBUNDLE + "Load Async")]
	internal class AssetBundle_LoadAsync : MonoBehaviour
	{
		public void Invoke()
		{
			string rootPath = Application.dataPath;
			if(Application.isEditor) { rootPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6); }
			string fullPath = Path.Combine(rootPath, _URI);
			var request = AssetBundle.LoadFromFileAsync(fullPath);
			request.priority = _priority;
			request.completed += op =>
			{
				if(request.assetBundle != null) { _onOutput.Invoke(request.assetBundle); }
			};
			StartCoroutine(ProgressRoutine(request));
		}

		[SerializeField] internal int _priority = 0;
		[SerializeField] internal string _URI = "";
		[SerializeField] internal UnityEvent<AssetBundle> _onOutput = null;
		[SerializeField] internal UnityEvent<float> _onProgress = null;

		private IEnumerator ProgressRoutine(AssetBundleCreateRequest request)
		{
			if(_onProgress.GetPersistentEventCount() > 0)
			{
				while(!request.isDone)
				{
					_onProgress.Invoke(request.progress);
					yield return null;
				}
				_onProgress.Invoke(1f);
			}
		}
	}
}

#endif