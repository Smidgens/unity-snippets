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
	internal abstract class Cast<TIn, TOut> : MonoBehaviour
	{
		public void Invoke(TIn x)
		{
			TOut y;
			if(TryParse(x, out y)) { EmitOutput(y); }
			else { EmitError(); }
		}

		protected abstract bool TryParse(TIn x, out TOut y);

		private void EmitOutput(TOut y) => _out.Invoke(y);

		private void EmitError() => _fail.Invoke();

		[SerializeField] internal UnityEvent<TOut> _out = null;
		[SerializeField] internal UnityEvent _fail = default;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Cast<,>), true)]
	internal sealed class _Convert : __BasicEditor
	{
		protected override string[] GetEventFields() => _TABS;

		private static readonly string[] _TABS =
		{
			nameof(Cast<int,bool>._out),
			nameof(Cast<int,bool>._fail),
		};
	}
}

#endif