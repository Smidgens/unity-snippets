// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.CONVERT_VECTOR2 + "→ Vector3")]
	internal class Convert_Vector2_Vector3 : MonoBehaviour
	{
		public void Invoke(Vector2 value) => _onResult.Invoke(Convert(_axes, value));

		internal enum AxisConversion { Y2Y, Y2Z }

		[SerializeField] internal AxisConversion _axes = AxisConversion.Y2Y;
		[SerializeField] internal UnityEvent<Vector3> _onResult = null;

		private static Vector3 Convert(in AxisConversion c, in Vector2 v)
		{
			return c switch
			{
				AxisConversion.Y2Y => new Vector3(v.x, v.y, 0),
				AxisConversion.Y2Z => new Vector3(v.x, 0, v.y),
				_ => v,
			};
		}
	}
}