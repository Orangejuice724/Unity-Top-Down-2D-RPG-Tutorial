using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicVillager : Villager {

	public Transform target;
	public List<ListOfShops> listOfShops = new List<ListOfShops>();
	public Transform shop;

	public bool goToTarget = false;
	public bool goHome = false;
	public bool generateTarget = false;

	public int distance;

	void Start () {
		setupColours();
		changeSpritesColour();
		shop = GameObject.FindGameObjectWithTag("Shop").transform;
	}
	

	void Update () 
	{
		if(direction == 0)
		{
			spriteParent.sprite = forward;
			changeSpritesColour();
		}
		if(direction == 1)
		{
			spriteParent.sprite = backward;
			changeSpritesColour();
		}
		if(direction == 2)
		{
			spriteParent.sprite = left;
			changeSpritesColour();
		}
		if(direction == 3)
		{
			spriteParent.sprite = right;
			changeSpritesColour();
		}

		if(goToTarget == true)
			GoToTarget();
		else if(goHome == true)
			GoHome();
		else if(generateTarget == true)
			StartCoroutine(GenerateTarget());
	}

	IEnumerator GenerateTarget()
	{
		generateTarget = false;
		yield return new WaitForSeconds(1);
		int r = Random.Range(0, 100);
		if(r > 50)
			newShopTarget();
		generateTarget = true;
	}

	public void newShopTarget()
	{
		int j = Random.Range(0, listOfShops.Count);
		target = shop;
		goToTarget = true;
	}

	public void GoToTarget()
	{
		if(Vector2.Distance(transform.position, target.position) < 2)
		{
			goHome = true;
			goToTarget = false;
			target = null;
		}

		if(target.transform.position.y > (rigidbody2D.transform.position.y))
		{
			rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if(target.transform.position.y < (rigidbody2D.transform.position.y))
		{
			rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if(target.transform.position.x > (rigidbody2D.transform.position.x))
		{
			rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(target.transform.position.x < (rigidbody2D.transform.position.x))
		{
			rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
		}
	}

	public void GoHome()
	{
		if(home.transform.position.y > (rigidbody2D.transform.position.y + distance))
		{
			rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if(home.transform.position.y < (rigidbody2D.transform.position.y - distance))
		{
			rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if(home.transform.position.x > (rigidbody2D.transform.position.x + distance))
		{
			rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(home.transform.position.x < (rigidbody2D.transform.position.x - distance))
		{
			rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if(Vector2.Distance(home.position, target.position) < 3)
		{
			goHome = false;
		}
	}
}

[System.Serializable]
public class ListOfShops
{
	public string shopName;
	public Transform shopT;
}