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
	internal abstract class Convert<TIn, TOut> : MonoBehaviour
	{
		public void Invoke(TIn x)
		{
			TOut y;
			if(TryParse(x, out y)) { EmitOutput(y); }
			else { EmitError(); }
		}

		protected abstract bool TryParse(TIn x, out TOut y);

		private void EmitOutput(TOut y) => _onResult.Invoke(y);

		private void EmitError() => _onError.Invoke();

		[SerializeField] internal UnityEvent _onError = default;
		[SerializeField] internal UnityEvent<TOut> _onResult = null;
	}
}