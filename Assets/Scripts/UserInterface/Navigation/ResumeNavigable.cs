using UnityEngine;
using System.Collections;

public class ResumeNavigable : Navigable {

	Controller controller;

	void Start(){
		Init();
	}

	override public void Action(){
		controller.SwitchPauseResume();
	}

	override public void Init(){
		base.Init();
		controller = GameObject.Find("Board").GetComponent<Controller>();
	}


}
