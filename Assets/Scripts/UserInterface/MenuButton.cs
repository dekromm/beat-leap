﻿using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown()
	{
		if (gameObject.name == "play"){
						Application.LoadLevel ("title");
		}else{
			if (gameObject.name == "credits"){
			Application.LoadLevel ("credits");
			}else{
				if (gameObject.name == "exit"){
						Application.Quit();
				}else{
					if (gameObject.name == "instructions"){
						Application.LoadLevel("Instructions");
					}
				}
			}
		}

	}
}
