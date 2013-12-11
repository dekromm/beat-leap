using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	Controller controller;

	void Start () {
		controller = GameObject.Find("Board").GetComponent<Controller>();
	}

	void OnMouseDown(){
		if(gameObject.name == "TouchLeft"){
			controller.gameMechanics.MoveLeft();
		}else if(gameObject.name == "TouchRight"){
			controller.gameMechanics.MoveRight();
		}else if(gameObject.name == "TouchUp"){
			controller.gameMechanics.MoveUp();
		}else if(gameObject.name == "TouchDown"){
			controller.gameMechanics.MoveDown();
		}else if(gameObject.name == "Center"){
			controller.SwitchPauseResume();
		}
	}
}
