using UnityEngine;
using System.Collections;

public class ReloadLevelNavigable : Navigable {

	void Start(){
		Init();
	}
	
	override public void Action(){
		Application.LoadLevel(Game.Current().gameScene);
	}

}
