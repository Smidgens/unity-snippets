// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.SCENE + "Load Async (index)")]
	[UnityDocumentation("SceneManagement.SceneManager.LoadSceneAsync")]
	[TabbedEvents]
	internal sealed class SM_LoadSceneAsync_Index : Snippet
	{
		public void In()
		{
			// busy
			if(_currentRequest != null) { return; }

			AsyncOperation request = SceneManager.LoadSceneAsync(_index, _mode);
			request.priority = _priority;
			request.allowSceneActivation = true;
			request.completed += op =>
			{
				_out.Invoke(SceneManager.GetSceneByBuildIndex(_index));
			};
			StartCoroutine(ProgressRoutine(request));
		}

		[SerializeField] private Wrapped_Int _index = new Wrapped_Int(-1);
		[SerializeField] private Wrapped_Int _priority = new Wrapped_Int(0);
		[SerializeField] private LoadSceneMode _mode = LoadSceneMode.Single;
		[SerializeField] private UnityEvent<Scene> _out = null;
		[SerializeField] private UnityEvent<float> _progress = null;

		private AsyncOperation _currentRequest = null;

		private IEnumerator ProgressRoutine(AsyncOperation request)
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