// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis")]
	[UnityDocumentation("Input.GetAxis")]
	internal sealed class Input_GetAxis : MonoBehaviour
	{
		public void In() => _out.Invoke(GetAxis());

		[SerializeField] internal WrappedValue_String _axis = default;
		[SerializeField] internal UnityEvent<float> _out = null;

		private float GetAxis() => Input.GetAxis(_axis);

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Input_GetAxis), true)]
	internal sealed class _Input_GetAxis : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Input_GetAxis._axis),
			null,
			nameof(Input_GetAxis._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}
#endif