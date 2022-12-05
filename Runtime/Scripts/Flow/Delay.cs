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
		public void In(float delay) => InvokeDelay(delay);

		[SerializeField] internal UnityEvent _out = null;

		private void InvokeDelay(in float delay)
		{
			if (delay < 0) { return; }
			StartCoroutine(InvokeRoutine(delay));
		}

		private IEnumerator InvokeRoutine(float t)
		{
			yield return new WaitForSeconds(t);
			_out.Invoke();
		}
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Delay))]
	internal class _Delay : __BasicEditor
	{
		protected override string[] GetFields() => _FNAMES;

		private static readonly string[] _FNAMES =
		{
			nameof(Delay._out)
		};
	}
}
#endif