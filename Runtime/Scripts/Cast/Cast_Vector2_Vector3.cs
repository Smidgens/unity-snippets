// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	// map vector2 to vector3
	[AddComponentMenu(Constants.ACM.CONVERT_VECTOR2 + "→ Vector3")]
	internal class Cast_Vector2_Vector3 : Snippet
	{
		public void In(Vector2 value) => _out.Invoke(Convert(_axes, value));

		internal enum AxisConversion { Y2Y, Y2Z }

		[SerializeField] internal AxisConversion _axes = AxisConversion.Y2Y;
		[SerializeField] internal UnityEvent<Vector3> _out = null;

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