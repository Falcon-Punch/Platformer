using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private List<Slot> slots = new List<Slot>();

	public void Start()
	{

	}

	public void InsertItem(Item item)
	{
		//slots[0].Insert(item);

		foreach(Slot slot in slots)
		{
			if(!slot.IsFull)
			{
				slot.Insert(item);
				return;
			}
		}
	}
}
