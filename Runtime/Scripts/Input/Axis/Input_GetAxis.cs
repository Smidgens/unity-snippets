// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis")]
	[UnityDocumentation("Input.GetAxis")]
	internal sealed class Input_GetAxis : Snippet
	{
		public void In() => _out.Invoke(GetAxis());

		[SerializeField] private Wrapped_String _axis = default;
		[Space]
		[SerializeField] private UnityEvent<float> _out = null;

		private float GetAxis() => Input.GetAxis(_axis);

	}
}