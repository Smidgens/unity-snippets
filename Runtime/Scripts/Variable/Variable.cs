// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[DisallowMultipleComponent]
	internal abstract class Variable : Snippet { }
	
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
		[SerializeField] protected T _value = default;
		[SerializeField] protected bool _readOnly = false;

	}
}