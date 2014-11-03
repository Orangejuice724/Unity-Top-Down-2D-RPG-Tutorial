using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	public float speed;

	public bool isHostile;

	public int health;
	public int maxHealth;

	public Sprite forward;
	public Sprite backward;
	public Sprite left;
	public Sprite right;
	public SpriteRenderer spriteParent;

	public Color[] cArray;
	public Color skinColourBase;
	public Color hairColourBase;
	public Color eyeColourBase;
	public Color shirtColourBase;
	public Color shoeColourBase;
	public Color pantsColourBase;
	public Color skinColour;
	public Color hairColour;
	public Color eyeColour;
	public Color shirtColour;
	public Color shoeColour;
	public Color pantsColour;

	public Texture2D newTexture;

	protected int texWidth;
	protected int texHeight;

	public int direction = 0;

	void Start () {
		texWidth = 32;
		texHeight = 32;
		cArray = new Color[texWidth * texHeight];
		//changeSpritesColour();
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

	public void setupColours()
	{
		skinColourBase = new Color(1.0f, 1.0f, 0, 1.0f);
		hairColourBase = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		eyeColourBase = new Color(0.0f, 1.0f, 1.0f, 1.0f);
		shirtColourBase = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		shoeColourBase = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		pantsColourBase = new Color(0.0f, 0.0f, 1.0f, 1.0f);
	}

	public void changeSpritesColour()
	{
		texWidth = 32;
		texHeight = 32;
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

	/*public void changeSpritesColour()
	{
		Texture2D newTexture = new Texture2D(texWidth, texHeight, TextureFormat.ARGB32, false);
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
	}*/
}
