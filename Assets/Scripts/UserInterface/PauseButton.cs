using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown(){

		if (gameObject.name == "RestartButton")
			Application.LoadLevel("Game");
		else if (gameObject.name == "MenuButton")
			Application.LoadLevel ("Main");
	
	}
}
