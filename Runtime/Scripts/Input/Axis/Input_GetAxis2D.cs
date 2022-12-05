// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_AXIS + "Axis 2D")]
	[UnityDocumentation("Input.GetAxis")]
	internal sealed class Input_GetAxis2D : MonoBehaviour
	{
		public void In() => _out.Invoke(GetAxis2D());

		[SerializeField] internal WrappedValue_String _xAxis = default;
		[SerializeField] internal WrappedValue_String _yAxis = default;
		[SerializeField] internal UnityEvent<Vector2> _out = null;

		private Vector2 GetAxis2D() => new Vector2(Input.GetAxis(_xAxis), Input.GetAxis(_yAxis));

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Input_GetAxis2D), true)]
	internal sealed class _Input_GetAxis2D : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Input_GetAxis2D._xAxis),
			nameof(Input_GetAxis2D._yAxis),
			null,
			nameof(Input_GetAxis2D._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}
#endif