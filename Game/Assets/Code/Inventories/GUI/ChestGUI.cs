using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestGUI : MonoBehaviour {

	public GUISkin guiSkin;
	public Texture2D chestGUI;

	public List<inventory> chestInv = new List<inventory>();
	public List<Slot> slots = new List<Slot>();

	public bool drawInventory;

	void Start () {
		for(int i = 0; i < slots.Count; i++)
		{
			slots[i].setupSlots();
		}
	}

	void Update () {
		
	}

	void OnGUI()
	{
		if(drawInventory)
		{
			GUI.DrawTexture(new Rect((Screen.width / 2) - 128, (Screen.height / 2) - 128, 256, 256), chestGUI);
			for(int i = 0; i < slots.Count; i++)
			{
				if(chestInv[i] != null)
				{
					GUI.DrawTexture(new Rect(slots[i].x, slots[i].y, 32, 32), chestInv[i].item.itemSprite.texture);
				}
			}
		}
	}

	public void giveIventory(List<inventory> i)
	{
		this.chestInv = i;
	}
}

[System.Serializable]
public class Slot
{
	public int x, y;
	public bool right, bottom;

	public Slot(int x, int y)
	{
		if(right)
			this.x = (Screen.width / 2) + x - 32;
		else
			this.x = (Screen.width / 2) - x;
		if(bottom)
			this.y = (Screen.height / 2) + y - 32;
		else
			this.y = (Screen.height / 2) - y;
	}

	public void setupSlots()
	{
		if(right)
			x = (Screen.width / 2) + x - 32;
		else
			x = (Screen.width / 2) - x;
		if(bottom)
			y = (Screen.height / 2) + y - 32;
		else
			y = (Screen.height / 2) - y;
	}
}