using UnityEngine;
using System.Collections;

public class QuitNavigable : Navigable {
	
	void Start () {
		Init();	
	}

	override public void Action(){
		Application.Quit();
	}

}
