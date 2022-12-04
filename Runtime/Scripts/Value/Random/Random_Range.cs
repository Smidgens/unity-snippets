// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Emit random value on [min,max]
	/// </summary>
	[AddComponentMenu(Constants.ACM.RANDOM + "Range")]
	internal sealed class Random_Range : MonoBehaviour
	{
		public float Min { get => _min; set => _min = value; }
		public float Max { get => _max; set => _max = value; }

		public void Invoke() => _onValue.Invoke(GetRandom(_min, _max));

		[SerializeField] private float _min = 0, _max = 1f;
		[SerializeField] private UnityEvent<float> _onValue = null;

		private static float GetRandom(in float min, in float max) => Random.Range(min, max);
	}
}