using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	Controller controller;

	void Start () {
		controller = GameObject.Find("Board").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void OnMouseDown(){

		if (gameObject.name == "RestartButton"){
			Application.LoadLevel(Config.config.gameScene);
		}else{ 
			if (gameObject.name == "MenuButton"){
				Application.LoadLevel ("Main");
			}else{
				if(gameObject.name == "ResumeButton"){
					controller.SwitchPauseResume();	
				}
			}
		}
	}
}
