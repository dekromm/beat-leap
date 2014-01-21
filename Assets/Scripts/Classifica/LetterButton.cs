using UnityEngine;
using System.Collections;

public class LetterButton : MonoBehaviour {

	private char letter= 'A';
	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = this.GetComponent("TextMesh") as TextMesh;
		Debug.Log((int) letter);
		letter = 'Z';
		Debug.Log((int) letter);
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
