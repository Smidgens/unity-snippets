// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.SceneManagement;

	[AddComponentMenu(Constants.ACM.SCENE + "Load (index)")]
	[UnityDocumentation("SceneManagement.SceneManager.LoadScene")]
	internal sealed class SM_LoadScene_Index : Snippet
	{
		[SerializeField] private Wrapped_Int _index = new Wrapped_Int(-1);

		[Space]
		[SerializeField] private UnityEvent _out = default;

		public void In()
		{
			if(_index < 0) { return; }
			SceneManager.LoadScene(_index);
			_out.Invoke();
		}
	}
}