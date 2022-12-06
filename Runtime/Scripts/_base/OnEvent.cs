// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnEvent : Snippet
	{
		protected void Invoke() => _out.Invoke();

		[SerializeField] protected UnityEvent _out = default;
	}
}


namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnEvent<T> : Snippet
	{
		protected void Invoke(in T v) => _out.Invoke(v);

		[SerializeField] protected UnityEvent<T> _out = default;
	}

}

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class OnEvent<T1, T2> : Snippet
	{
		protected void Invoke(in T1 v1, in T2 v2) => _out.Invoke(v1, v2);

		[SerializeField] protected UnityEvent<T1, T2> _out = default;
	}
}

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[RequireComponent(typeof(Collider))]
	internal abstract class OnColliderEvent : OnEvent { }

}