using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDController : MonoBehaviour {

	public Player thisplayer;

	public Texture healthbar;
	public Texture healthbarOuter;
	public Texture coin;

	public bool isInInventory = false;

	public float percentage;

	public GUISkin guiSKIN;

	private int currentlySelected;
	private int maxSelected;

	void Start () {
		currentlySelected = 1;
	}

	void Update () {
		percentage = Mathf.Clamp(thisplayer.health * 2.5f, 0, 250);

		if(Input.GetKeyDown(KeyCode.I))
			isInInventory = !isInInventory;

		if(isInInventory)
			Time.timeScale = 0.0f;
		else
			Time.timeScale = 1.0f;

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(maxSelected > 1)
			{
				if(currentlySelected == maxSelected)
				{
					currentlySelected = 1;
				}
				else
				{
					currentlySelected++;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			if(maxSelected > 1)
			{
				if(currentlySelected == 1)
				{
					currentlySelected = maxSelected;
				}
				else
				{
					currentlySelected--;
				}
			}
		}
	}

	void OnGUI()
	{
		GUI.skin = guiSKIN;
		if(!isInInventory)
		{
			health ();
			money ();
		}

		if(isInInventory)
			Inventory();
	}

	void health()
	{
		GUI.DrawTexture(new Rect(55, Screen.height - 100, percentage, 60), healthbar);
		GUI.DrawTexture(new Rect(20, Screen.height - 120, 320, 100), healthbarOuter);
	}

	void money()
	{
		GUI.DrawTexture(new Rect(20, 20, 60, 60), coin);
		GUI.Label(new Rect(100, 20, 200, 60), "$" + thisplayer.money);
	}

	void Inventory()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", "invbg");
		GUI.Box (new Rect(Screen.width-((Screen.width/100f)*50f), 0, ((Screen.width/100f)*50f), ((Screen.height/100f)*75f)), "", "item-box");
		GUI.Box (new Rect(0, Screen.height-((Screen.height/100f)*25f), Screen.width, ((Screen.height/100f)*25f)), "", "info-box");

		List<inventory> playerInv = thisplayer.ipManager.items;

		maxSelected = playerInv.Count;

		for(int i = 1; i < playerInv.Count+1; i++)
		{
			if(i == currentlySelected)
			{
				GUI.color = new Color(15.0f, 0.0f, 0.0f);
				GUI.Label(new Rect(Screen.width-((Screen.width/100f)*50f)+10, (i*20), 500, 30), playerInv[i-1].item.itemName + " x " + playerInv[i-1].amountOfItem);
				
				GUI.color = new Color(0.0f, 0.0f, 0.0f);
				GUI.Label(new Rect(20, Screen.height-((Screen.height/100f)*25f)+20, 500, 30), playerInv[i-1].item.itemDescrition);
			}
			else
			{
				GUI.color = new Color(0.0f, 0.0f, 0.0f);
				GUI.Label(new Rect(Screen.width-((Screen.width/100f)*50f)+10, (i*20), 500, 30), playerInv[i-1].item.itemName + " x " + playerInv[i-1].amountOfItem);
			}
		}
	}
}
