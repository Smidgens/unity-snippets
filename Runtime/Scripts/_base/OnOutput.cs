namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnOutput<TOut> : Snippet
	{
		public void In() => _out.Invoke(Get());
		protected abstract TOut Get();

		[SerializeField] private UnityEvent<TOut> _out = null;
	}
}