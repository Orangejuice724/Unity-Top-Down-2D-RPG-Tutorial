using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

	public bool playerInRange;
	public bool isShopOpen;

	public Player player;

	public Shop thisShop;

	public GUISkin gskin;

	public string warn;
	public bool showWarn = false;

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
			player = c.GetComponent<Player>();
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.tag == "Player" && playerInRange)
		{
			playerInRange = false;
			player = null;
			isShopOpen = false;
		}
	}

	void OnGUI()
	{
		GUI.skin = gskin;
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
			GUILayout.Label("");
			GUILayout.Space(20);
			GUILayout.EndHorizontal();
			foreach(shopInventory i in thisShop.sellingItems)
			{
				GUILayout.BeginHorizontal(GUILayout.Width(500));

				GUILayout.Label(i.item.itemName, "Shop");

				GUILayout.Label("$" + i.price.ToString(), "Shop");

				GUILayout.Label(i.amountOfItem.ToString(), "Shop");

				if(GUILayout.Button("Buy"))
				{
					if(player.money >= i.price)
						thisShop.removeItemFromShop(thisShop.sellingItems.IndexOf(i), player);
					else
						StartCoroutine(waitForWarning("Not enough money!"));

				}

				GUILayout.Space(20);

				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();

			GUILayout.EndArea();

			if(showWarn)
			{
				GUI.Box(new Rect(Screen.width / 2 - 250, 20, 500, 60), warn);
			}
		}
	}

	IEnumerator waitForWarning(string warning)
	{
		warn = warning;
		showWarn = true;
		yield return new WaitForSeconds(5);
		showWarn = false;
	}
}
