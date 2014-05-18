using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public List<Items> items = new List<Items>();

	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
	
	}
}

[System.Serializable]
public class Items
{
	public Transform itemTransform;
}