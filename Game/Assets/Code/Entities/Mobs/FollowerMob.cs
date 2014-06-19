using UnityEngine;
using System.Collections;

public class FollowerMob : Entity {

	public Entity following;
	public float distance;

	void Start () {
		setupColours();
		changeSpritesColour();
	}

	void Update () 
	{
		if(following.rigidbody2D.transform.position.y > (rigidbody2D.transform.position.y + distance))
		{
			rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if(following.rigidbody2D.transform.position.y < (rigidbody2D.transform.position.y - distance))
		{
			rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if(following.rigidbody2D.transform.position.x > (rigidbody2D.transform.position.x + distance))
		{
			rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if(following.rigidbody2D.transform.position.x < (rigidbody2D.transform.position.x - distance))
		{
			rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
		}

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

		if(health <= 0)
			Die ();

		texWidth = 32;
		texHeight = 32;
		changeSpritesColour();
	}

	public void Die()
	{

	}
}
