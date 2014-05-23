using UnityEngine;
using System.Collections;

public class Player : Entity {

	public ItemPlayerManager ipManager;

	public Sprite forward;
	public Sprite backward;
	public Sprite left;
	public Sprite right;
	public SpriteRenderer spriteParent;

	public SpriteRenderer weaponSpriteParent;
	public Vector2 forwardPos, backPos, sidePos;

	public int direction;

	public WeaponManager weaponManager;

	void Start () {
		ipManager.addToItemInventory(0, 5);
		foreach(Weapons w in weaponManager.weapons)
		{
			if(w.isHolding)
			{
				weaponSpriteParent.sprite = w.weaponSprite;
				if(w.weaponType == WeaponType.Sword)
				{
					Sword sword = weaponSpriteParent.gameObject.AddComponent("Sword") as Sword;
					sword.minDamage = 15;
					sword.maxDamage = 25;
				}
			}
		}
	}

	void Update () 
	{
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
			direction = 1;
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
			direction = 0;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
			direction = 2;
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
			direction = 3;
		}

		if(direction == 0)
		{
			spriteParent.sprite = forward;
			weaponSpriteParent.sortingOrder = 21;
			Quaternion newRot = Quaternion.Euler(0, 0, 0);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = forwardPos;
		}
		if(direction == 1)
		{
			spriteParent.sprite = backward;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler(0, 0, 90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = backPos;
		}
		if(direction == 2)
		{
			spriteParent.sprite = left;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler(0, 0, 90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
		}
		if(direction == 3)
		{
			spriteParent.sprite = right;
			weaponSpriteParent.sortingOrder = 21;
			Quaternion newRot = Quaternion.Euler(0, 0, 0);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
		}

		if(health <= 0)
			Die ();
	}

	public void Die()
	{
		print ("I've been killed");
	}
}
