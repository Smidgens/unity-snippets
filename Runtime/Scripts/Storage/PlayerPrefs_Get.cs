// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class PlayerPrefs_Get<T> : MonoBehaviour
	{
		public void Invoke() => _out.Invoke(GetValue());

		protected delegate T Getter(string key, T defaultValue);

		protected abstract Getter GetGetter();

		[SerializeField] internal WrappedValue_String _key = default;
		[SerializeField] internal T _default = default;
		[SerializeField] internal UnityEvent<T> _out = default;

		private T GetValue() => GetGetter().Invoke(_key, _default);
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(PlayerPrefs_Get<>), true)]
	internal sealed class _PlayerPrefs_Get : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(PlayerPrefs_Get<float>._key),
			nameof(PlayerPrefs_Get<float>._default),
			null,
			nameof(PlayerPrefs_Get<float>._out),
		};
		protected override string[] GetFields() => _FNAMES;
	}
}

#endif