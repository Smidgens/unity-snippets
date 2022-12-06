// smidgens @ github

#if SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.ASSETBUNDLE + "Load From File Async")]
	[UnityDocumentation("AssetBundle.LoadFromFileAsync")]
	[TabbedEvents]
	internal sealed class AssetBundle_LoadFromFileAsync : MonoBehaviour
	{
		public void In()
		{
			string rootPath = Application.dataPath;
			if(Application.isEditor) { rootPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6); }
	
			var request = AssetBundle.LoadFromFileAsync(_path);
			request.priority = _priority;
			request.completed += op =>
			{
				if(request.assetBundle != null) { _out.Invoke(request.assetBundle); }
			};
			StartCoroutine(ProgressRoutine(request));
		}

		[SerializeField] internal Wrapped_Int _priority = new Wrapped_Int(0);
		[SerializeField] internal Wrapped_String _path = new Wrapped_String("");
		[SerializeField] internal UnityEvent<AssetBundle> _out = null;
		[SerializeField] internal UnityEvent<float> _progress = null;

		private IEnumerator ProgressRoutine(AssetBundleCreateRequest request)
		{
			if(_progress.GetPersistentEventCount() > 0)
			{
				while(!request.isDone)
				{
					_progress.Invoke(request.progress);
					yield return null;
				}
				_progress.Invoke(1f);
			}
		}
	}
}

#endif