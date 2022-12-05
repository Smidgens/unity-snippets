// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_CUSTOM + "Emit")]
	internal sealed class CustomEvent_Emit : MonoBehaviour
	{
		public void Invoke() => CustomEvent.Emit(_event);
		[SerializeField] internal string _event = "";
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(CustomEvent_Emit), true)]
	internal sealed class _CustomEvent_Emit : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(CustomEvent_Emit._event),
			null,
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif