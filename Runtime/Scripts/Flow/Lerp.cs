// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Lerp")]
	internal class Lerp : MonoBehaviour
	{
		public float Duration
		{
			get => _duration;
			set => _duration = value;
		}

		// invoke default
		public void Invoke() => StartLerp(_duration);
		
		// stop active lerp
		public void Abort()
		{
			_activeFading = 0;
			StopAllCoroutines();
			_onAbort.Invoke();
		}

		[Min(0f)]
		[SerializeField] internal float _duration = 2f;
		[SerializeField] internal UnityEvent _onStart = null;
		[SerializeField] internal UnityEvent<float> _onStep = null;
		[SerializeField] internal UnityEvent _onExit = null;
		[SerializeField] internal UnityEvent _onAbort = null;

		private int _activeFading = 0;

		public void StartLerp(in float duration)
		{
			if(_duration <= 0f) { return; }
			if (_activeFading > 0) { return; }
			if (!gameObject.activeInHierarchy) { return; }
			_activeFading++;
			StartCoroutine(FadeRoutine(duration));
		}

		private void InvokeListeners(float t) => _onStep.Invoke(t);

		private IEnumerator FadeRoutine(float fadeTime)
		{
			_onStart.Invoke();
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
			_onExit.Invoke();
		}
	}
}