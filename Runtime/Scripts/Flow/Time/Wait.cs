// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Wait")]
	[UnityDocumentation("WaitForSeconds")]
	internal sealed class Wait : Snippet
	{
		// invoke outside delay
		public void Enter()
		{
			float delay = _duration.GetValue();
			if (delay < 0) { return; }
			StartCoroutine(WaitRoutine(delay, Out));
		}

		// abort active delay(s)
		public void Abort() => StopAllCoroutines();

		// wait duration
		[SerializeField] private Wrapped_Float _duration = new Wrapped_Float(1f);

		// post-delay handlers
		[Space]
		[SerializeField] private UnityEvent _exit = null;

		// invoke output
		private void Out() => _exit.Invoke();

		private static IEnumerator WaitRoutine(float t, System.Action doneFn)
		{
			// Note: consider caching WaitForSeconds instance
			yield return new WaitForSeconds(t);
			doneFn.Invoke();
		}
	}
}