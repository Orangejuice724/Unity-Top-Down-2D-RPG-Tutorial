using UnityEngine;
using System.Collections;

public class FollowerMob : Entity {

	public Entity following;
	public float distance;

	public Texture2D newTexture;

	void Start () {
	
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

		if(health <= 0)
			Die ();

		texWidth = 32;
		texHeight = 32;
		changeSpritesColour();
	}

	public void Die()
	{

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
