// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;


	internal abstract class OnEventBase : MonoBehaviour { }

	internal abstract class OnEvent : OnEventBase
	{
		protected void Invoke() => _out.Invoke();

		[SerializeField] internal UnityEvent _out = default;
	}

	[RequireComponent(typeof(Collider))]
	internal abstract class OnColliderEvent : OnEvent
	{
	}


	internal abstract class OnEvent<T> : OnEventBase
	{
		protected void Invoke(in T v) => _out.Invoke(v);

		[SerializeField] private UnityEvent<T> _out = default;
	}

	internal abstract class OnEvent<T1,T2> : OnEventBase
	{
		protected void Invoke(in T1 v1, in T2 v2) => _out.Invoke(v1, v2);

		[SerializeField] private UnityEvent<T1,T2> _out = default;
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
			nameof(OnEvent._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif
