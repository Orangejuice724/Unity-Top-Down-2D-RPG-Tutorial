using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public float speed;

	public int health;

	void Start () {
		
	}


	void Update () {

	}

	public void takeHealth(int amount)
	{
		health = health - amount;
	}
}
