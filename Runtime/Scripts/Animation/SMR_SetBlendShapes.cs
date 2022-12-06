// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.ANIMATION_SMR + "Set Blend Shapes")]
	[UnityDocumentation("SkinnedMeshRenderer.SetBlendShapeWeight")]
	[DrawArraysAsLists]
	internal sealed class SMR_SetBlendShapes : Snippet
	{
		public void In(float v)
		{
			for(int i = 0; i < _shapes.Length; i++)
			{
				_shapes[i].Value = v;
			}
		}

		[SerializeField] private BlendShapeReference[] _shapes = {};
	}
}