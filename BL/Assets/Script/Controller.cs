using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	const KeyCode UP = KeyCode.UpArrow;
	const KeyCode DOWN = KeyCode.DownArrow;
	const KeyCode RIGHT = KeyCode.RightArrow;
	const KeyCode LEFT = KeyCode.LeftArrow;
	const KeyCode PAUSE = KeyCode.Escape;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// OnGUI is called once for every event in unity
	// this means it is frame-indepent, making it the right place
	// where to put the input capture. Maybe.
	void OnGUI(){
		if(	Event.current.type.Equals(EventType.KeyDown) ) {
			if( Event.current.keyCode.CompareTo(UP) == 0 ){

				//Model.up()

			} else if( Event.current.keyCode.CompareTo(DOWN) == 0 ){

				//Model.down()

			} else if( Event.current.keyCode.CompareTo(LEFT) == 0 ){

				//Model.left()

			} else if( Event.current.keyCode.CompareTo(RIGHT) == 0 ){
				
				//Model.right()
				
			} else if( Event.current.keyCode.CompareTo(PAUSE) == 0 ){
				
				//Model.pause()
				
			}
		}
	}

}
