using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sword : MonoBehaviour {

	public int minDamage;
	public int maxDamage;
	private int realDamage;

	public List<Entity> enemyInRange = new List<Entity>();

	void Start () {
	
	}

	void Update () {
		if(Input.GetMouseButtonDown(0))
			attack();
	}

	public void attack()
	{
		realDamage = Random.Range(minDamage, maxDamage);
		foreach(Entity e in enemyInRange)
		{
			e.takeHealth(realDamage);
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		Entity tempEnt = other.GetComponent<Entity>();
		if(tempEnt != null)
		{
			if(tempEnt.isHostile)
			{
				if(enemyInRange.Contains(tempEnt))
					return;
				enemyInRange.Add(tempEnt);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Entity tempEnt = other.GetComponent<Entity>();
		if(tempEnt != null)
		{
			int index = enemyInRange.IndexOf(tempEnt);
			enemyInRange.Remove(enemyInRange[index]);
		}
	}
}
