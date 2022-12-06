// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Poisson Disk")]
	[WikipediaArticle("Supersampling#Poisson_disk")]
	internal sealed class Random_Poisson : Snippet
	{
		public void In() => _out.Invoke(GeneratePoints().ToArray());

		[SerializeField] private Wrapped_Vector2 _size = new Wrapped_Vector2(Vector2.one);
		[SerializeField] private Wrapped_Float _radius = new Wrapped_Float(1f);
		[SerializeField] private Wrapped_Int _rejectionSamples = new Wrapped_Int(30);

		[Space]
		[SerializeField] private UnityEvent<Vector2[]> _out = null;

		private List<Vector2> GeneratePoints() => Poisson.Sample(_radius, _size, _rejectionSamples);
	}

}