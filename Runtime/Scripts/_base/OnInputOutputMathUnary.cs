// smidgens @ github


namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnInputOutput<TIn, TLeft, TOut> : MonoBehaviour
	{
		public void In(TIn rhs) => _out.Invoke(Compute(_l, rhs));

		protected abstract TOut Compute(in TLeft lhs, in TIn rhs);

		[SerializeField] internal TLeft _l = default;
		[SerializeField] internal UnityEvent<TOut> _out = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnInputOutput<,,>), true)]
	internal sealed class _OnInputOutput3 : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnInputOutput<float,float,float>._l),
			null,
			nameof(OnInputOutput<float,float,float>._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif
