// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnKeyCode : Snippet
	{
		public void In()
		{
			if (!Get(_key)) { return; }
			Invoke();
		}

		protected abstract bool Get(KeyCode key);

		[SerializeField] protected KeyCode _key = KeyCode.None;
		[Space]
		[SerializeField] protected UnityEvent _out = null;

		private void Invoke() => _out.Invoke();

	}
}