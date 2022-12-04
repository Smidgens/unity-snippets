// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.ANIMATION_SMR + "Set Blend Shapes")]
	internal sealed class SMR_SetBlendShapes : MonoBehaviour
	{
		public void In(float v)
		{
			for(int i = 0; i < _shapes.Length; i++)
			{
				_shapes[i].Value = v;
			}
		}

		[SerializeField] internal BlendShapeReference[] _shapes = {};

		[Serializable]
		internal struct BlendShapeReference
		{
			public float Value
			{
				set => _renderer.SetBlendShapeWeight(_index, Mathf.Clamp01(value));
				get => _renderer.GetBlendShapeWeight(_index);
			}

			public float NormalizedValue
			{
				get => _renderer.GetBlendShapeWeight(_index) / 100f;
				set => _renderer.SetBlendShapeWeight(_index, Mathf.Clamp01(value) * 100f);
			}

			[SerializeField] private SkinnedMeshRenderer _renderer;
			[SerializeField] private int _index;
		}
	}
}