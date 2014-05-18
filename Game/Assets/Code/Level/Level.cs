using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private int levelWidth;
	private int levelHeight;

	public Transform grassTile;
	public Transform stoneBrickTile;
	public Transform enemy;

	private Color[] tileColours;

	public Color grassColour;
	public Color stoneBrickColour;
	public Color spawnPointColour;
	public Color enemyPointColour;

	public Texture2D levelTexture;

	public Entity player;
	public Entity[] friendlyEntities;

	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadLevel();
	}

	void Update () {
	
	}

	void loadLevel()
	{
		tileColours = new Color[levelWidth * levelHeight];
		tileColours = levelTexture.GetPixels();

		for(int y = 0; y < levelHeight; y++)
		{
			for(int x = 0; x < levelWidth; x++)
			{
				if(tileColours[x+y*levelWidth] == grassColour)
				{
					Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
				}
				if(tileColours[x+y*levelWidth] == stoneBrickColour)
				{
					Instantiate(stoneBrickTile, new Vector3(x, y), Quaternion.identity);
				}
				if(tileColours[x+y*levelWidth] == spawnPointColour)
				{
					Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
					Vector2 pos = new Vector2(x, y);
					player.transform.position = pos;
					for(int i = 0; i < friendlyEntities.Length; i++)
					{
						Vector2 npos = pos;
						npos.x += i + 1;
						friendlyEntities[i].transform.position = npos;
					}
				}
				if(tileColours[x+y*levelWidth] == enemyPointColour)
				{
					Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
					Instantiate(enemy, new Vector3(x, y), Quaternion.identity);
				}
			}
		}
	}
}
