// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnInputOutput<TIn, TOut> : Snippet
	{
		public void In(TIn v) => _out.Invoke(Get(v));
		protected abstract TOut Get(in TIn v);

		[SerializeField] protected UnityEvent<TOut> _out = null;
	}
}

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnInputOutput<TIn, TLeft, TOut> : Snippet
	{
		public void In(TIn rhs) => _out.Invoke(Compute(_l, rhs));

		protected abstract TOut Compute(in TLeft lhs, in TIn rhs);

		[SerializeField] protected TLeft _l = default;
		[Space]
		[SerializeField] protected UnityEvent<TOut> _out = null;
	}
}


namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class MathOperator : Snippet
	{
		public void In(float rhs) => _out.Invoke(Compute(rhs));

		protected abstract float Compute(in float rhs);

		[SerializeField] protected Wrapped_Float _LHS = default;
		[Space]
		[SerializeField] protected UnityEvent<float> _out = null;
	}
}