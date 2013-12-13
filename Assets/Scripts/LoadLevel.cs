using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	void OnMouseDown(){
		Game.Current().SetLevel(gameObject.name);
		Application.LoadLevel("Game");
	}

}
