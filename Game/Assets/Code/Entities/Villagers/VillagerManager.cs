using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillagerManager : MonoBehaviour {

	public List<Villagers> villagers = new List<Villagers>();

	void Start () {
	
	}

	void Update () {
	
	}

	public Villager findVillagerByVillagerType(VillagerTypes vType)
	{
		Villagers v = new Villagers();
		foreach(Villagers vv in villagers)
		{
			if(vv.vType == vType)
				v = vv;
		}
		if(v != null)
			return v.villager.GetComponent<Villager>();
		else
			return null;
	}

	public GameObject findVillagerGameObjectByVillagerType(VillagerTypes vType)
	{
		Villagers v = new Villagers();
		foreach(Villagers vv in villagers)
		{
			if(vv.vType == vType)
				v = vv;
		}
		if(v != null)
			return v.villager;
		else
			return null;
	}
}

[System.Serializable]
public class Villagers
{
	public GameObject villager;
	public VillagerTypes vType;
}

public enum VillagerTypes
{
	Basic,
	Worker,
	Blacksmith,
	Trader,
	ShopKeeper
}