// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONTROL + "Flip")]
	internal sealed class Flip : MonoBehaviour
	{
		// invoke default
		public void In(bool v) => _onOutput.Invoke(!v);

		[SerializeField] internal UnityEvent<bool> _onOutput = null;
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Flip))]
	internal sealed class _Flip : __BasicEditor
	{
		protected override string GetMessageText() => "Flips input";
	}
}
#endif