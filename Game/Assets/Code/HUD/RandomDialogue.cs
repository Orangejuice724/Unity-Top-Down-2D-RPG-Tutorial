using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomDialogue : MonoBehaviour {

	private bool showingDialogue;

	public Level levelManager;

	private string dialogueMessage;
	public List<Dialogue> dialogueMessages = new List<Dialogue>();

	public GUISkin skinn;

	void Start () 
	{
		levelManager = GameObject.FindGameObjectWithTag("levelManager").GetComponent<Level>();
	}

	void Update () 
	{
		if(showingDialogue)
		{
			if(Input.GetKeyDown(KeyCode.Return))
				GenerateDialogue();
		}
	}

	void OnGUI()
	{
		GUI.skin = skinn;
		GUI.depth = 0;
		if(showingDialogue && !levelManager.hc.isInInventory)
		{
			GUI.Box (new Rect(10, Screen.height - 130, Screen.width - 20, 120), dialogueMessage, "Dialogue");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<Player>() != null && showingDialogue == false)
		{
			GenerateDialogue();
			showingDialogue = true;
		}
	}

	public void GenerateDialogue()
	{
		int random = Random.Range(0, dialogueMessages.Count - 1);
		dialogueMessage = dialogueMessages[random].dialogue;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.GetComponent<Player>() != null)
		{
			showingDialogue = false;
		}
	}
}

[System.Serializable]
public class Dialogue
{
	public string dialogue;
}