// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_TIMING + "Transition")]
	internal class Transition : MonoBehaviour
	{
		// invoke default
		public void In() => StartLerp(_duration);
		
		// stop active lerp
		public void Abort()
		{
			_activeFading = 0;
			StopAllCoroutines();
			_abort.Invoke();
		}

		[SerializeField] internal WrappedFloat _duration = new WrappedFloat(2f);
		[SerializeField] internal UnityEvent<float> _tick = null;
		[SerializeField] internal UnityEvent _out = null;
		[SerializeField] internal UnityEvent _abort = null;

		private int _activeFading = 0;

		public void StartLerp(in float duration)
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
			_out.Invoke();
		}
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Transition))]
	internal sealed class _Transition : __BasicEditor
	{
		protected override string[] GetFields() => _FNAMES;
		protected override string[] GetEventFields() => _TABS;

		private static readonly string[] _FNAMES =
		{
			nameof(Transition._duration)
		};

		private static readonly string[] _TABS =
		{
			nameof(Transition._tick),
			nameof(Transition._out),
			nameof(Transition._abort),
		};

	}
}
#endif
