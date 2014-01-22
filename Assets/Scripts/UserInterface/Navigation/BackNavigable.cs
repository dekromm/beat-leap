using UnityEngine;
using System.Collections;

public class BackNavigable : Navigable {
	
	void Start(){
		Init();
	}

	override public void Action(){
		Application.LoadLevel("Main");
	}
}
