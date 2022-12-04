// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;


	internal abstract class OnEventBase : MonoBehaviour { }

	internal abstract class OnEvent : OnEventBase
	{
		protected void Invoke() => _onEvent.Invoke();

		[SerializeField] internal UnityEvent _onEvent = default;
	}

	internal abstract class OnEvent<T> : OnEventBase
	{
		protected void Invoke(in T v) => _onEvent.Invoke(v);

		[SerializeField] private UnityEvent<T> _onEvent = default;
	}

	internal abstract class OnEvent<T1,T2> : OnEventBase
	{
		protected void Invoke(in T1 v1, in T2 v2) => _onEvent.Invoke(v1, v2);

		[SerializeField] private UnityEvent<T1,T2> _onEvent = default;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnEventBase), true)]
	internal sealed class _OnEvent : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnEvent._onEvent),
		};

		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif
