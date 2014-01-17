using UnityEngine;
using System.Collections;

public class SwipeOrTouch : MonoBehaviour {

	public TextMesh swipeortouch;
	public GameObject swipe;

	void Start () {
		swipe = GameObject.Find("_SwipeInput") as GameObject;
		if(Game.Current().swipeInput){
			swipeortouch.text = "Swipe";
		}else{
			swipeortouch.text = "Touch";
		}
	}
	
	void OnMouseDown () {
		Game.Current().swipeInput = !Game.Current().swipeInput;
		if(Game.Current().swipeInput){
			swipeortouch.text = "Swipe";
			swipe.SetActive(true);
		}else{
			swipeortouch.text = "Touch";
			swipe.SetActive(false);
		}
	}
}
