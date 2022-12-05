// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	internal abstract class PlayerPrefs_Set<T> : MonoBehaviour
	{
		public void Invoke(T value) => SetValue(value);

		protected delegate void Setter(string key, T value);

		protected abstract Setter GetSetter();

		[SerializeField] internal string _key = "";

		private void SetValue(T v) => GetSetter().Invoke(_key, v);
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(PlayerPrefs_Set<>), true)]
	internal sealed class _PlayerPrefs_Set : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(PlayerPrefs_Set<float>._key),
			null,
		};
		protected override string[] GetFields() => _FNAMES;
	}
}

#endif