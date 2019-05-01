namespace Smidgenomics.Generate
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityRandom = UnityEngine.Random;

	[AddComponentMenu("Smidgenomics/Generate/Poisson Rect Distribution")]
	internal class PoissonRectDistribution : MonoBehaviour
	{
		public Vector2 areaSize = Vector2.one;
		public float radius = 1;
		public int rejectionSamples = 30;

		public void DoDistribution()
		{
			if(_resultType == ResultType.Array) { _onArrayResult.Invoke(GeneratePoints().ToArray()); }
			else { _onListResult.Invoke(GeneratePoints()); }
		}

		private enum ResultType { Array, List };
		[Serializable] private class ListResultEvent : UnityEvent<List<Vector2>>{}
		[Serializable] private class ArrayResultEvent : UnityEvent<Vector2[]>{}
		[SerializeField] private ResultType _resultType = ResultType.Array;
		[SerializeField] private ListResultEvent _onListResult = null;
		[SerializeField] private ArrayResultEvent _onArrayResult = null;

		private List<Vector2> GeneratePoints()
		{
			return PoissonDiscSampling.GeneratePoints(radius, areaSize, rejectionSamples);
		}
	}

	// source:
	// https://www.youtube.com/watch?v=7WcmyxyFO7o
	// https://github.com/SebLague/Poisson-Disc-Sampling/blob/master/Poisson%20Disc%20Sampling%20E01/PoissonDiscSampling.cs

	internal static class PoissonDiscSampling
	{
		public static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize, int numSamplesBeforeRejection = 30)
		{
			float cellSize = radius/Mathf.Sqrt(2);
			int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x/cellSize), Mathf.CeilToInt(sampleRegionSize.y/cellSize)];
			List<Vector2> points = new List<Vector2>();
			List<Vector2> spawnPoints = new List<Vector2>();
			spawnPoints.Add(sampleRegionSize/2);
			while (spawnPoints.Count > 0)
			{
				int spawnIndex = UnityRandom.Range(0,spawnPoints.Count);
				Vector2 spawnCentre = spawnPoints[spawnIndex];
				bool candidateAccepted = false;
				for (int i = 0; i < numSamplesBeforeRejection; i++)
				{
					float angle = UnityRandom.value * Mathf.PI * 2;
					Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
					Vector2 candidate = spawnCentre + dir * UnityRandom.Range(radius, 2*radius);
					if (IsValid(candidate, sampleRegionSize, cellSize, radius, points, grid))
					{
						points.Add(candidate);
						spawnPoints.Add(candidate);
						grid[(int)(candidate.x/cellSize),(int)(candidate.y/cellSize)] = points.Count;
						candidateAccepted = true;
						break;
					}
				}
				if (!candidateAccepted)
				{
					spawnPoints.RemoveAt(spawnIndex);
				}
			}
			return points;
		}

		static bool IsValid(Vector2 candidate, Vector2 sampleRegionSize, float cellSize, float radius, List<Vector2> points, int[,] grid)
		{
			if (candidate.x >=0 && candidate.x < sampleRegionSize.x && candidate.y >= 0 && candidate.y < sampleRegionSize.y)
			{
				int cellX = (int)(candidate.x/cellSize);
				int cellY = (int)(candidate.y/cellSize);
				int searchStartX = Mathf.Max(0,cellX -2);
				int searchEndX = Mathf.Min(cellX+2,grid.GetLength(0)-1);
				int searchStartY = Mathf.Max(0,cellY -2);
				int searchEndY = Mathf.Min(cellY+2,grid.GetLength(1)-1);

				for (int x = searchStartX; x <= searchEndX; x++)
				{
					for (int y = searchStartY; y <= searchEndY; y++)
					{
						int pointIndex = grid[x,y]-1;
						if (pointIndex != -1)
						{
							float sqrDst = (candidate - points[pointIndex]).sqrMagnitude;
							if (sqrDst < radius * radius)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			return false;
		}
	}

}

#if UNITY_EDITOR

namespace Smidgenomics.Generate
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(PoissonRectDistribution))]
	internal class Editor_PoissonRectDistribution : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_areaSize);
			EditorGUILayout.PropertyField(_radius);
			EditorGUILayout.PropertyField(_rejectionSamples);
			EditorGUILayout.PropertyField(_resultType);
			EditorGUILayout.PropertyField(_resultType.enumValueIndex == 0 ? _arrayResult : _listResult, new GUIContent("On Result"));
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _areaSize = null;
		private SerializedProperty _radius = null;
		private SerializedProperty _rejectionSamples = null;
		private SerializedProperty _listResult = null;
		private SerializedProperty _arrayResult = null;
		private SerializedProperty _resultType = null;

		private void OnEnable()
		{
			_areaSize = serializedObject.FindProperty("areaSize");
			_radius = serializedObject.FindProperty("radius");
			_rejectionSamples = serializedObject.FindProperty("rejectionSamples");
			_listResult = serializedObject.FindProperty("_onListResult");
			_arrayResult = serializedObject.FindProperty("_onArrayResult");
			_resultType = serializedObject.FindProperty("_resultType");
		}
	}
}
#endif