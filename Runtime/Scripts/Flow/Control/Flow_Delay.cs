// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Delay")]
	internal sealed class Flow_Delay : Snippet
	{
		// invoke outside delay
		public void In(float delay)
		{
			if (delay < 0) { return; }
			StartCoroutine(WaitRoutine(delay, Out));
		}

		// abort active delay(s)
		public void Abort() => StopAllCoroutines();

		// post-delay handlers
		[SerializeField] private UnityEvent _out = null;

		// invoke output
		private void Out() => _out.Invoke();

		private static IEnumerator WaitRoutine(float t, System.Action doneFn)
		{
			// Note: consider caching WaitForSeconds instance
			yield return new WaitForSeconds(t);
			doneFn.Invoke();
		}
	}
}