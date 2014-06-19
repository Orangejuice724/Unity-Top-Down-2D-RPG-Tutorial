using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

	public string shopName;

	public List<shopInventory> sellingItems = new List<shopInventory>();

	void Start () {
	
	}

	void Update () {
	
	}
}

[System.Serializable]
public class shopInventory
{
	public Item item;
	public int amountOfItem;
	public int price;
	
	public shopInventory(Item item, int amountOfItem)
	{
		this.item = item;
		this.amountOfItem = amountOfItem;
	}
}