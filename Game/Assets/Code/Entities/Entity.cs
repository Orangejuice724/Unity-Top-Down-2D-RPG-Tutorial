using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public float speed;

	public bool isHostile;

	public int health;

	void Start () {
		
	}


	void Update () {

	}

	public void takeHealth(int amount)
	{
		health = health - amount;
	}

	public void TPToPos(Vector2 pos)
	{
		rigidbody2D.transform.position = pos;
	}
}
