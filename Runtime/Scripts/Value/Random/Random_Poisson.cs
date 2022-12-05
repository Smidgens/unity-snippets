// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Poisson Disk")]
	[WikipediaArticle("Supersampling#Poisson_disk")]
	internal sealed class Random_Poisson : MonoBehaviour
	{
		public void DoDistribution() => _out.Invoke(GeneratePoints());

		[SerializeField] internal Wrapped_Vector2 _areaSize = new Wrapped_Vector2(Vector2.one);

		[SerializeField] internal WrappedFloat _radius = new WrappedFloat(1f);
		[SerializeField] internal Wrapped_Int _rejectionSamples = new Wrapped_Int(30);
		[SerializeField] internal UnityEvent<IEnumerable<Vector2>> _out = null;

		private List<Vector2> GeneratePoints() => Poisson.Sample(_radius, _areaSize, _rejectionSamples);
	}

}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random_Poisson))]
	internal sealed class _Random_Poisson : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Random_Poisson._areaSize),
			nameof(Random_Poisson._radius),
			nameof(Random_Poisson._rejectionSamples),
			null,
			nameof(Random_Poisson._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}
#endif