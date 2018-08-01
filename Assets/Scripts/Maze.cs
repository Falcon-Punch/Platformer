using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{ 
	[SerializeField] private List<Cell> cells = new List<Cell>();

	private void Start()
	{
		//foreach (Cell cell in cells)
		//{
		//	cell.TargetNeighbors();
		//}

		BuildEdge(cells[5]);
	}

	// Generate Maze

	private void BuildEdge(Cell cell)
	{
		cell.Visited = true;
		Cell neighbor = cell.GetRandomNeighbor();

		if(neighbor != null)
		{
			Debug.Log("Null Neighbor!?" + neighbor.name);
			Debug.DrawLine(cell.transform.position, neighbor.transform.position, Color.green, 10);

			BuildEdge(neighbor);
		}
	}
}
