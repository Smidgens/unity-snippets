// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Emit random value on [min,max]
	/// </summary>
	[AddComponentMenu(Constants.ACM.RANDOM + "Range")]
	[UnityDocumentation("Random.Range")]
	internal sealed class Random_Range : Snippet
	{
		public float Min { get => _min; set => _min.StaticValue = value; }
		public float Max { get => _max; set => _max.StaticValue = value; }

		public void Invoke() => _out.Invoke(GetRandom(_min, _max));

		[SerializeField] private Wrapped_Float _min = new Wrapped_Float(0f);
		[SerializeField] private Wrapped_Float _max = new Wrapped_Float(1f);

		[Space]
		[SerializeField] private UnityEvent<float> _out = null;

		private static float GetRandom(in float min, in float max) => Random.Range(min, max);
	}
}