using UnityEngine;
using System.Collections;

public class LoadSceneNavigable : Navigable {

	public string sceneName;

	void Start () {
		base.Init();
	}

	override public void Action(){
		Application.LoadLevel(sceneName);
	}
	
}
