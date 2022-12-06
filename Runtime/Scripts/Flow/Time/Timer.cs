// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Timer")]
	[TabbedEvents]
	internal sealed class Timer : Snippet
	{
		// invoke default
		public void Enter() => StartTimer(_duration);
		
		// stop active lerp
		public void Abort()
		{
			_activeFading = 0;
			StopAllCoroutines();
			_abort.Invoke();
		}

		[SerializeField] private Wrapped_Float _duration = new Wrapped_Float(2f);
		[SerializeField] private UnityEvent<float> _tick = null;
		[SerializeField] private UnityEvent _exit = null;
		[SerializeField] private UnityEvent _abort = null;

		private int _activeFading = 0;

		public void StartTimer(in float duration)
		{
			if(duration <= 0f) { return; }
			if (_activeFading > 0) { return; }
			if (!gameObject.activeInHierarchy) { return; }
			_activeFading++;
			StartCoroutine(FadeRoutine(duration));
		}

		private void InvokeListeners(float t) => _tick.Invoke(t);

		private IEnumerator FadeRoutine(float fadeTime)
		{
			float start = Time.time;
			yield return null;
			float elapsed = 0;
			while (elapsed < fadeTime)
			{
				elapsed = Time.time - start;
				InvokeListeners(Mathf.Clamp(elapsed / fadeTime, 0, 1));
				yield return null;
			}
			InvokeListeners(1f);
			_activeFading--;
			_exit.Invoke();
		}
	}
}