// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.EVENT_AUDIO + "On Audio Filter Read")]
	internal sealed class Animator_OnAudioFilterRead : OnEvent<float[],int>
	{
		private void OnAudioFilterRead(float[] data, int channels) => Invoke(data, channels);
	}
}