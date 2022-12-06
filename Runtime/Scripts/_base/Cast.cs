// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Converts input type to output type
	/// </summary>
	/// <typeparam name="TIn">Input</typeparam>
	/// <typeparam name="TOut">Output</typeparam>
	internal abstract class Cast<TIn, TOut> : Snippet
	{
		public void In(TIn x)
		{
			TOut y;
			if(TryParse(x, out y)) { EmitOutput(y); }
			else { EmitError(); }
		}

		protected abstract bool TryParse(TIn x, out TOut y);

		private void EmitOutput(TOut y) => _out.Invoke(y);

		private void EmitError() => _fail.Invoke();

		[SerializeField] private UnityEvent<TOut> _out = null;
		[SerializeField] private UnityEvent _fail = default;
	}
}