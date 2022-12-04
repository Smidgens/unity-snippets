// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Delay")]
	internal sealed class Delay : MonoBehaviour
	{
		// invoke outside delay
		public void Invoke(float delay) => InvokeDelay(delay);

		[SerializeField] internal UnityEvent _onExit = null;

		private void InvokeDelay(in float delay)
		{
			if (delay < 0) { return; }
			StartCoroutine(InvokeRoutine(delay));
		}

		private IEnumerator InvokeRoutine(float t)
		{
			yield return new WaitForSeconds(t);
			_onExit.Invoke();
		}
	}
}