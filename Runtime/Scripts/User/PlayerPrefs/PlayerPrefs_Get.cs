// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class PlayerPrefs_Get<T> : Snippet
	{
		public void In() => _out.Invoke(GetValue());

		protected delegate T Getter(string key, T defaultValue);

		protected abstract Getter GetGetter();

		[SerializeField] protected Wrapped_String _key = default;
		[SerializeField] protected T _default = default;
		[Space]
		[SerializeField] protected UnityEvent<T> _out = default;

		private T GetValue() => GetGetter().Invoke(_key, _default);
	}
}