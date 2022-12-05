// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnKeyCode : MonoBehaviour
	{
		public void In()
		{
			if (!Get(_key)) { return; }
			Invoke();
		}

		protected abstract bool Get(KeyCode key);

		[SerializeField] internal KeyCode _key = KeyCode.None;
		[SerializeField] internal UnityEvent _out = null;

		private void Invoke() => _out.Invoke();

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnKeyCode), true)]
	internal sealed class _Input_KeyCode : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnKeyCode._key),
			null,
			nameof(OnKeyCode._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}
#endif