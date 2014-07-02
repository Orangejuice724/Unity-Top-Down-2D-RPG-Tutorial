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

	public void removeItemFromShop(int index)
	{
		sellingItems[index].amountOfItem = sellingItems[index].amountOfItem - 1;
		if(sellingItems[index].amountOfItem <= 0)
			sellingItems.Remove(sellingItems[index]);
	}

	public void removeItemFromShop(int index, Player pl)
	{
		pl.takeMoney(sellingItems[index].price);
		pl.ipManager.addToItemInventory(sellingItems[index].item.id, 1);
		sellingItems[index].amountOfItem = sellingItems[index].amountOfItem - 1;
		if(sellingItems[index].amountOfItem <= 0)
			sellingItems.Remove(sellingItems[index]);

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