using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	public bool playerInRange;
	public bool isShopOpen;

	public Shop thisShop;

	void Start () {
		playerInRange = false;
		isShopOpen = false;
	}

	void Update () 
	{
		if(playerInRange)
		{
			if(Input.GetKeyDown(KeyCode.E))
				isShopOpen = !isShopOpen;
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if(c.tag == "Player" && playerInRange == false)
		{
			print ("There's a player at the shop");
			playerInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.tag == "Player" && playerInRange)
		{
			playerInRange = false;
			isShopOpen = false;
		}
	}

	void OnGUI()
	{
		if(playerInRange && !isShopOpen)
		{
			GUI.Label(new Rect(5, 5, 500, 100), "Press e to visit the " + thisShop.shopName);
		}

		if(isShopOpen)
		{
			GUILayout.BeginArea(new Rect((Screen.width / 2) - 250, 100, 500, Screen.height - 200), GUIContent.none, "box");

			GUILayout.Label("What we're selling!");
			GUILayout.BeginVertical();
			GUILayout.BeginHorizontal(GUILayout.Width(500));
			GUILayout.Label("Item");
			GUILayout.Label("Price");
			GUILayout.Label("Amount");
			GUILayout.EndHorizontal();
			foreach(shopInventory i in thisShop.sellingItems)
			{
				GUILayout.BeginHorizontal(GUILayout.Width(500));

				GUILayout.Label(i.item.itemName);

				GUILayout.Label("$" + i.price.ToString());

				GUILayout.Label(i.amountOfItem.ToString());

				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();

			GUILayout.EndArea();
		}
	}
}
