// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[DisallowMultipleComponent]
	internal abstract class Variable : MonoBehaviour { }

	
	internal abstract class Variable<T> : Variable
	{
		public T Value
		{
			get => _value;
			set
			{
				if (_readOnly) { return; }
				_value = value;
			}
		}
		[SerializeField] internal T _value = default;
		[SerializeField] internal bool _readOnly = false;

	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Variable<>), true)]
	internal sealed class _Variable : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Variable<int>._value),
			nameof(Variable<int>._readOnly),
			null,
		};
		protected override string[] GetFields() => _FNAMES;
	}
}
#endif