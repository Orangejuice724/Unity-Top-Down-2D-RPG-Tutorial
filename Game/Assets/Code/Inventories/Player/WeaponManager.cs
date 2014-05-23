using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public List<Weapons> weapons;

	void Start () {
	
	}

	void Update () 
	{
		
	}
}

[System.Serializable]
public class Weapons
{
	public string name;
	public WeaponType weaponType;
	public Sprite weaponSprite;

	public bool isHolding;
}

public enum WeaponType
{
	Sword,
	Bow
}