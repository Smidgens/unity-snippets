// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.ANIMATION_SMR + "Set Blend Shapes")]
	[UnityDocumentation("SkinnedMeshRenderer.SetBlendShapeWeight")]
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
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(SMR_SetBlendShapes))]
	internal sealed class _SetBlendShapes : __BasicEditor
	{
		protected override void OnInit()
		{
			_plist = new PropList(serializedObject.FindProperty(nameof(SMR_SetBlendShapes._shapes)));
		}

		protected override void OnBeforeProps()
		{
			_plist.DoLayoutList();
		}

		private PropList _plist = null;
	}
}

#endif