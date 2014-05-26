using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	private Vector2 roomPos;
	public Transform roomSpawnT;
	private Vector2 leavePos;

	void Start () {
		Vector2 tpos = new Vector2(0, 0);
		tpos.x = transform.position.x;
		tpos.y = transform.position.y - 2;
		leavePos = tpos;
		roomPos = roomSpawnT.transform.position;
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
