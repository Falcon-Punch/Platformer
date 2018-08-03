using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	[SerializeField] private List<Cell> neighbors = new List<Cell>();

	public bool Visited = false;

	public void TargetNeighbors()
	{
		foreach (Cell neighbor in neighbors)
		{
			Debug.DrawLine(transform.position, neighbor.transform.position/*+ new Vector3(0, 1, 0)*/, Color.blue, 150);
		}


		//Debug.Log("Here.");
		//Debug.DrawLine(transform.position, transform.position + new Vector3(0, 1, 0), Color.blue, 5);
	}

	public Cell GetRandomNeighbor()
	{
		if (neighbors.Count > 0)
		{
			int random = Random.Range(0, neighbors.Count);

			if (neighbors[random].Visited == false)
			{
				Cell neighbor = neighbors[random];  // Store a brief reference.
				neighbors.RemoveAt(random);         // Remove from our list.

				return neighbor;
			}
			else
			{
				// Remove and check for more neighbors
				neighbors.RemoveAt(random);

				return GetRandomNeighbor();
			}
		}
		return null;
	}
}
