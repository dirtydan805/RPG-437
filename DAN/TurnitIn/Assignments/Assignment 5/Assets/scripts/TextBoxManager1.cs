using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager1 : MonoBehaviour {
	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;
	public playerControl player;

	// Use this for initialization
	void Start () {
		if(textFile != null)
		{
			player = FindObjectOfType<playerControl>();
			textLines = (textFile.text.Split ('\n'));
		}
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}

			
	}
	void Update()
	{
		theText.text = textLines [currentLine];
	}



}
