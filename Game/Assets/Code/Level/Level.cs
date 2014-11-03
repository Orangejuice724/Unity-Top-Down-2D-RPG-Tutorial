using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	private int levelWidth;
	private int levelHeight;

	public Transform enemy;
	public Transform parent;

	public HUDController hc;

	private Color[] tileColours;
	private Color[] topTileColours;
	public Color spawnPointColour;
	public Color enemyPointColour;

	public Texture2D levelTexture;
	public Texture2D topTileTexture;

	public Entity player;
	public Entity[] friendlyEntities;

	public List<Tile> tiles = new List<Tile>();

	void Start () {
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadLevel();
		loadTopTiles();
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
				foreach(Tile t in tiles)
				{
					if(tileColours[x+y*levelWidth] == t.tileColor)
					{
						Instantiate(t.tileTransform, new Vector3(x, y), Quaternion.identity);
					}
				}
				if(tileColours[x+y*levelWidth] == spawnPointColour)
				{
					Instantiate(tiles[0].tileTransform, new Vector3(x, y), Quaternion.identity);
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
					Instantiate(tiles[0].tileTransform, new Vector3(x, y), Quaternion.identity);
					Instantiate(enemy, new Vector3(x, y), Quaternion.identity);
				}
			}
		}
	}

	void loadTopTiles()
	{
		topTileColours = new Color[topTileTexture.width * topTileTexture.height];
		topTileColours = topTileTexture.GetPixels();

		for(int y = 0; y < levelHeight; y++)
		{
			for(int x = 0; x < levelWidth; x++)
			{
				foreach(Tile t in tiles)
				{
					if(topTileColours[x+y*levelWidth] == t.tileColor)
					{
						Instantiate(t.tileTransform, new Vector3(x, y), Quaternion.identity);
					}
				}
			}
		}
	}
}

[System.Serializable]
public class Tile
{
	public string tileName;

	public Color tileColor;
	public Transform tileTransform;
}