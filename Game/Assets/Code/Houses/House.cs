using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	private Vector2 roomPos;
	public Transform roomSpawnT;
	private Vector2 leavePos;

	public VillagerManager villagerManager;

	public List<HouseFamily> hFamily = new List<HouseFamily>();

	void Start () {
		Vector2 tpos = new Vector2(0, 0);
		tpos.x = transform.position.x;
		tpos.y = transform.position.y - 2;
		leavePos = tpos;
		roomPos = roomSpawnT.transform.position;

		SpawnFamily();
	}

	void SpawnFamily()
	{
		foreach(HouseFamily hf in hFamily)
		{
			GameObject vil = Instantiate(villagerManager.findVillagerGameObjectByVillagerType(hf.vType), new Vector2(transform.position.x, transform.position.y - 3), Quaternion.identity) as GameObject;
			vil.GetComponent<Villager>().home = transform;
		}
	}

	void Update () 
	{
	
	}

	public void GotoRoom(Entity e)
	{
		e.TPToPos(roomPos);
	}

	public void LeaveHouse(Entity e)
	{
		e.TPToPos(leavePos);
	}
}

[System.Serializable]
public class HouseFamily
{
	public string firstName;
	public string lastName;
	public VillagerTypes vType;
}
