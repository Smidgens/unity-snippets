// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.PLAYER_PREFS + "Has Key")]
	[UnityDocumentation("PlayerPrefs.HasKey")]
	internal sealed class PlayerPrefs_HasKey : Snippet
	{
		public void In() => _out.Invoke(KeyExists());

		[SerializeField] private Wrapped_String _key = new Wrapped_String("");
		[SerializeField] private UnityEvent<bool> _out = default;

		private bool KeyExists() => PlayerPrefs.HasKey(_key.GetValue());
	}
}