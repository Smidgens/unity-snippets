// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Set Hide Flags")]
	[UnityDocumentation("Object-hideFlags")]
	internal class GameObject_SetHideFlags : MonoBehaviour
	{
		public int Flags
		{
			get => (int)_flags;
			set => _flags = (HideFlags)value;
		}

		public void Invoke() => gameObject.hideFlags = _flags;

		[SerializeField] internal HideFlags _flags = HideFlags.None;
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CustomEditor(typeof(GameObject_SetHideFlags))]
	internal sealed class _GameObject_SetHideFlags : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(GameObject_SetHideFlags._flags)
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif