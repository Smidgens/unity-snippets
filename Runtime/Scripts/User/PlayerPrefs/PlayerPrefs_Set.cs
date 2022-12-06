// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	internal abstract class PlayerPrefs_Set<T> : Snippet
	{
		public void Invoke(T value) => SetValue(value);

		protected delegate void Setter(string key, T value);

		protected abstract Setter GetSetter();

		[SerializeField] protected string _key = "";

		private void SetValue(T v) => GetSetter().Invoke(_key, v);
	}
}