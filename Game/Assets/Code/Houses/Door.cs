using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool outsideDoor;
	public House house;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Entity e = c.GetComponent<Entity>();
		if(e != null)
		{
			if(outsideDoor)
			   house.GotoRoom(e);
			else
				house.LeaveHouse(e);
		}
	}
}
