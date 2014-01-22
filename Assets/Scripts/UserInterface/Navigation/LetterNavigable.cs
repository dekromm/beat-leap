using UnityEngine;
using System.Collections;

public class LetterNavigable : Navigable {

	private TextMesh letterMesh;
	private char letter;


	void Start () {
		Init();
	}

	override public void Init(){
		base.Init();
		letterMesh = gameObject.GetComponentInChildren<TextMesh>();
		letter = 'A';
	}

	override public void Action(){
		letter++;
		if (letter > 'Z')
			letter = 'A';
		letterMesh.text = "" + (char)(letter);
	}
}
