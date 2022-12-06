// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis 2D")]
	[UnityDocumentation("Input.GetAxis")]
	internal sealed class Input_GetAxis2D : Snippet
	{
		public void In() => _out.Invoke(GetAxis2D());

		[SerializeField] private Wrapped_String _xAxis = default;
		[SerializeField] private Wrapped_String _yAxis = default;
		[Space]
		[SerializeField] private UnityEvent<Vector2> _out = null;

		private Vector2 GetAxis2D() => new Vector2(Input.GetAxis(_xAxis), Input.GetAxis(_yAxis));

	}
}