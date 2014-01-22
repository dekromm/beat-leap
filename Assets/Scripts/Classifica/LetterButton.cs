using UnityEngine;
using System.Collections;

public class LetterButton : MonoBehaviour {

	private char letter;
	private TextMesh text;
	// Use this for initialization
	void Start () {
		letter= 'A';
		text = this.GetComponent("TextMesh") as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		letter++;
		if (letter > 'Z')
			letter = 'A';
		text.text = "" + (char)(letter);
	}
}
