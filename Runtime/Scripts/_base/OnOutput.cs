namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnOutput<TOut> : MonoBehaviour
	{
		public void Input() => _out.Invoke(Get());
		protected abstract TOut Get();

		[SerializeField] internal UnityEvent<TOut> _out = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnOutput<>), true)]
	internal sealed class _OnOutput : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnOutput<float>._out),
		};

		protected override string[] GetFields() => _FNAMES;

	}
}
#endif