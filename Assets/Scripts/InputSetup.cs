using UnityEngine;
using System.Collections;

public class InputSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Game.Current().isMobile){
			GameObject swipe = GameObject.Find("_SwipeInput");
			GameObject down = GameObject.Find("Down");
			GameObject left = GameObject.Find("Left");
			GameObject right = GameObject.Find("Right");
			GameObject up = GameObject.Find("Up");
			GameObject center = GameObject.Find("Center");

			if(Game.Current().swipeInput){
				swipe.SetActive(true);
				up.SetActive(false);
				right.SetActive(false);
				left.SetActive(false);
				down.SetActive(false);
			}else{
				swipe.SetActive(false);
				up.SetActive(true);
				right.SetActive(true);
				left.SetActive(true);
				down.SetActive(true);
			}
		}

	}
}
