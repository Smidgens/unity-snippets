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
	internal sealed class Random_Range : MonoBehaviour
	{
		public float Min { get => _min; set => _min.StaticValue = value; }
		public float Max { get => _max; set => _max.StaticValue = value; }

		public void Invoke() => _out.Invoke(GetRandom(_min, _max));

		[SerializeField] internal WrappedFloat _min = new WrappedFloat(0f);
		[SerializeField] internal WrappedFloat _max = new WrappedFloat(1f);
		[SerializeField] internal UnityEvent<float> _out = null;

		private static float GetRandom(in float min, in float max) => Random.Range(min, max);
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random_Range))]
	internal sealed class _Random_Range : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Random_Range._min),
			nameof(Random_Range._max),
			null,
			nameof(Random_Range._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif