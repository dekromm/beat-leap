using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	string level;

	void Start(){
		level = "Game";
		#if UNITY_IPHONE
		level = "Game_iPadx2";
		#endif
	}

	void OnMouseDown(){
		if(gameObject.name == "Menu"){
			Application.LoadLevel("Title");
		}else{
			Game.Current().SetLevel(gameObject.name);
			Application.LoadLevel(level);
		}
	}

}
