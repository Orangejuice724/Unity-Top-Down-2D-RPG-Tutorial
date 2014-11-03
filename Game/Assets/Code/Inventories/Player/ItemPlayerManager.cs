using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPlayerManager : MonoBehaviour {

	public ItemManager iManager;

	public List<inventory> items = new List<inventory>();

	void Start () {
	
	}

	void Update () 
	{
		
	}

	public void addToItemInventory(int itemId, int amount)
	{
		for(int i = 0; i < iManager.items.Count; i++)
		{
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				bool isItemInList = false;
				int index = 0;
				for(int j = 0; j < items.Count; j++)
				{
					if(items[j].item.id == itemId)
					{
						isItemInList = true;
						index = j;
					}
				}

				if(isItemInList)
				{
					items[index].amountOfItem += amount;
				}
				else
				{
					inventory inv = new inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
					items.Add (inv);
				}
			}
		}
	}
}

[System.Serializable]
public class inventory
{
	public Item item;
	public int amountOfItem;

	public inventory(Item item, int amountOfItem)
	{
		this.item = item;
		this.amountOfItem = amountOfItem;
	}
}
