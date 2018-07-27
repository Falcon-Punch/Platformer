using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
	[SerializeField] private Image Icon;
	private Item item;
	private bool is_full = false;

	public bool IsFull
	{
		get { return is_full; }
	}

	public void Insert(Item item)
	{
		this.item = item;
		Icon.sprite = item.Sprite;
		is_full = true;
	}

	// Hold items.
	// Trash Items
	// Use Items || equip || deploy
	// Icons of item.
	// Stack items.
}
