using UnityEngine;
using System.Collections;

public class Player : Entity {

	public ItemPlayerManager ipManager;

	public SpriteRenderer weaponSpriteParent;
	public Vector2 forwardPos, backPos, sidePos;

	public int direction;

	public Texture2D newTexture;

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

		texWidth = 32;
		texHeight = 32;
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
			changeSpritesColour();
		}
		if(direction == 1)
		{
			spriteParent.sprite = backward;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler(0, 0, 90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = backPos;
			changeSpritesColour();
		}
		if(direction == 2)
		{
			spriteParent.sprite = left;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler(0, 0, 90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
			changeSpritesColour();
		}
		if(direction == 3)
		{
			spriteParent.sprite = right;
			weaponSpriteParent.sortingOrder = 21;
			Quaternion newRot = Quaternion.Euler(0, 0, 0);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
			changeSpritesColour();
		}

		if(health <= 0)
			Die ();
	}

	public void Die()
	{
		print ("I've been killed");
	}

	public void changeSpritesColour()
	{
		newTexture = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
		newTexture.SetPixels(spriteParent.sprite.texture.GetPixels());
		cArray = newTexture.GetPixels();
		int y = 0;
		while(y < texHeight)
		{
			int x = 0;
			while(x < texWidth)
			{
				if(newTexture.GetPixel(x, y) == skinColourBase)
					newTexture.SetPixel(x, y, skinColour);
				if(newTexture.GetPixel(x, y) == hairColourBase)
					newTexture.SetPixel(x, y, hairColour);
				if(newTexture.GetPixel(x, y) == eyeColourBase)
					newTexture.SetPixel(x, y, eyeColour);
				if(newTexture.GetPixel(x, y) == shoeColourBase)
					newTexture.SetPixel(x, y, shoeColour);
				if(newTexture.GetPixel(x, y) == shirtColourBase)
					newTexture.SetPixel(x, y, shirtColour);
				if(newTexture.GetPixel(x, y) == pantsColourBase)
					newTexture.SetPixel(x, y, pantsColour);
				x++;
			}
			y++;
		}
		newTexture.wrapMode = TextureWrapMode.Clamp;
		newTexture.filterMode = FilterMode.Point;
		newTexture.Apply();
		spriteParent.sprite = Sprite.Create(newTexture, new Rect(0, 0, texWidth, texHeight), new Vector2(0.5f, 0.5f), 16);
	}
}
