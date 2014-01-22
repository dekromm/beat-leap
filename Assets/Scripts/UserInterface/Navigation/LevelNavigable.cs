using UnityEngine;
using System.Collections;

public class LevelNavigable : Navigable {

	public string levelName;
	
	void Start(){
		Init();
	}
	
	override public void Action(){
		Game.Current().SetLevel(levelName);
		Application.LoadLevel(Game.Current().gameScene);
	}

}
