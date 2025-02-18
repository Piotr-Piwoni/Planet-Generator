using EditorAttributes;
using UnityEngine;

namespace Mummoth
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class PlanetGenerator : MonoBehaviour
	{
		[SerializeField, ReadOnly]
		private Mesh _Mesh;
		[SerializeField, OnValueChanged(nameof(UpdateMaterial))]
		private Material _Material;
		[SerializeField]
		private int _Resolution = 1;

		private MeshFilter _MeshFilter;
		private MeshRenderer _MeshRenderer;


		private void Reset()
		{
			_MeshFilter = GetComponent<MeshFilter>();
			_MeshRenderer = GetComponent<MeshRenderer>();
			_Mesh = new Mesh();
			_MeshFilter.mesh = _Mesh;
		}

		private void UpdateMaterial()
		{
			_MeshRenderer.material = _Material;
		}

		[Button("Regenerate Mesh", 30f)]
		private void GenerateMesh()
		{
			Debug.Log("Generating mesh...");
			_Mesh.Clear();
			_Mesh.vertices = new[]
			{
				// Front.
				new Vector3(1.0f, 1.0f, 1.0f),
				new Vector3(1.0f, -1.0f, 1.0f),
				new Vector3(-1.0f, -1.0f, 1.0f),
				new Vector3(-1.0f, 1.0f, 1.0f),
				// Back.
				new Vector3(1.0f, 1.0f, -1.0f),
				new Vector3(1.0f, -1.0f, -1.0f),
				new Vector3(-1.0f, -1.0f, -1.0f),
				new Vector3(-1.0f, 1.0f, -1.0f)
			};
			_Mesh.triangles = new[]
			{
				// Front.
				0, 3, 2, 2, 1, 0,
				// Back.
				7, 4, 5, 5, 6, 7,
				// Left.
				3, 7, 6, 6, 2, 3,
				// Right.
				4, 0, 1, 1, 5, 4,
				// Top.
				3, 0, 4, 4, 7, 3,
				// Bottom.
				1, 2, 6, 6, 5, 1
			};
			_Mesh.RecalculateNormals();
			_Mesh.RecalculateTangents();
			_Mesh.RecalculateBounds();
		}
	}
}