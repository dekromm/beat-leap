using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	void Start () {
	
	}

	void OnMouseDown(){
		if(gameObject.name == "TouchLeft"){
			Controller.gameMechanics.MoveLeft();
		}else if(gameObject.name == "TouchRight"){
			Controller.gameMechanics.MoveRight();
		}else if(gameObject.name == "TouchUp"){
			Controller.gameMechanics.MoveUp();
		}else if(gameObject.name == "TouchDown"){
			Controller.gameMechanics.MoveDown();
		}
	}
}
