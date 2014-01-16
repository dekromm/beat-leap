using UnityEngine;
using System.Collections;

public class SignButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		FinalScore callee = GameObject.Find("Main Camera").GetComponent("FinalScore") as FinalScore;
		TextMesh letter1 = GameObject.Find("Letter1").GetComponent("TextMesh") as TextMesh;
		TextMesh letter2 = GameObject.Find("Letter2").GetComponent("TextMesh") as TextMesh;
		TextMesh letter3 = GameObject.Find("Letter3").GetComponent("TextMesh") as TextMesh;
		callee.SignScore(letter1.text + letter2.text + letter3.text);
		this.enabled = false;
	}
}
