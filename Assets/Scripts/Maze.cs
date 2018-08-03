using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
	[SerializeField] private GameObject BridgePrefab;
	[SerializeField] private List<Cell> cells = new List<Cell>();
	private List<Cell> breadcrumbs = new List<Cell>();

	private void Start()
	{
		//foreach (Cell cell in cells)
		//{
		//	cell.TargetNeighbors();
		//}

		GenerateEdge(cells[5]);
	}

	// Generate Maze

	private void GenerateEdge(Cell cell)
	{
		cell.Visited = true;

		if(!breadcrumbs.Contains(cell))
		{
			breadcrumbs.Add(cell);
		}

		Cell neighbor = cell.GetRandomNeighbor();

		if(neighbor != null)
		{
			AddEdge(cell, neighbor);

			GenerateEdge(neighbor);
		}
		else
		{
			// Dead end, so rewind.
			breadcrumbs.Remove(cell);

			if(breadcrumbs.Count > 0)
			{
				Cell last_cell = breadcrumbs[breadcrumbs.Count - 1];
				GenerateEdge(last_cell);
			}
		}
	}

	private void AddEdge(Cell from, Cell to)
	{
		Debug.DrawLine(from.transform.position, to.transform.position, Color.green, 10);

		// Place a cube inbetween two cells.
		// GameObject edge =	GameObject.CreatePrimitive(PrimitiveType.Cube);
		GameObject edge = Instantiate(BridgePrefab);
		edge.transform.SetParent(transform);

		edge.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
		edge.transform.position = Vector3.Lerp(from.transform.position, to.transform.position, 0.5f);

		
		edge.transform.LookAt(from.transform.position);
		edge.transform.position += new Vector3(0, 0.25f, 0);
	}
}
