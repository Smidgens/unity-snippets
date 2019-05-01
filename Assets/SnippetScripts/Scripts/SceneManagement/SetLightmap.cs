namespace Smidgenomics.SceneManagement
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Scene Management/Set Lightmap")]
	internal class SetLightmap : MonoBehaviour
	{
		public void ApplyLightmap()
		{
			int min = Mathf.Min(_directionalMaps.Length, _colorMaps.Length);
			LightmapData[] mapData = new LightmapData[min];
			for(int i = 0; i < min; i++)
			{
				mapData[i] = new LightmapData
				{
					lightmapColor = _colorMaps[i],
					lightmapDir = _directionalMaps[i],
					shadowMask = i < _shadowMasks.Length ? _shadowMasks[i] : null
				};
			}
			LightmapSettings.lightmaps = mapData;
		}

		public void SetMode(LightmapsMode mode)
		{
			LightmapSettings.lightmapsMode = mode;
		}

		public void SetDirectionalMaps(Texture2D[] maps) { _directionalMaps = maps; }
		public void SetColorMaps(Texture2D[] maps) { _colorMaps = maps; }
		public void SetShadowMasks(Texture2D[] maps) { _shadowMasks = maps; }

		[SerializeField] private Texture2D[] _directionalMaps = {};
		[SerializeField] private Texture2D[] _colorMaps = {};
		[SerializeField] private Texture2D[] _shadowMasks = {};
	}
}