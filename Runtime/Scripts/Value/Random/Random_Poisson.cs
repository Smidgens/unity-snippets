// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Poisson")]
	internal sealed class Random_Poisson : MonoBehaviour
	{
		public void DoDistribution() => _onOutput.Invoke(GeneratePoints());

		[SerializeField] private Vector2 _areaSize = Vector2.one;

		[Min(0f)]
		[SerializeField] private float _radius = 1f;
		[Min(1)]
		[SerializeField] private int _rejectionSamples = 30;
		[SerializeField] private UnityEvent<IEnumerable<Vector2>> _onOutput = null;

		private List<Vector2> GeneratePoints() => Poisson.Sample(_radius, _areaSize, _rejectionSamples);
	}

}