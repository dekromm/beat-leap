using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	const KeyCode UP = KeyCode.UpArrow;
	const KeyCode DOWN = KeyCode.DownArrow;
	const KeyCode RIGHT = KeyCode.RightArrow;
	const KeyCode LEFT = KeyCode.LeftArrow;
	const KeyCode PAUSE = KeyCode.Escape;
	const KeyCode RETURN = KeyCode.Return;

	private bool isGameStarted = false;
	private GameMechanics gameManager;
			
				// Use this for initialization
	void Start () {

		gameManager = new GameMechanics("test");	
	}
		
			// Update is called once per frame
	void Update () {
			
			}
		
			// OnGUI is called once for every event in unity
				// this means it is frame-indepent, making it the right place
				// where to put the input capture. Maybe.
	void OnGUI(){
		if(Event.current.type.Equals(EventType.KeyDown)){
			if(Event.current.keyCode.CompareTo(RETURN) == 0 && !isGameStarted){

				isGameStarted = true;
				//gameManager.StartPlaying();

							}else if( Event.current.keyCode.CompareTo(UP) == 0 ){
				
				//gameMechanics.MoveUp();
						
							} else if( Event.current.keyCode.CompareTo(DOWN) == 0 ){
				
				//gameMechanics.MoveDown();
						
							} else if( Event.current.keyCode.CompareTo(LEFT) == 0 ){
				
				//gameMechanics.MoveLeft();
						
							} else if( Event.current.keyCode.CompareTo(RIGHT) == 0 ){
								
				//gameMechanics.MoveRight();
										
							} else if( Event.current.keyCode.CompareTo(PAUSE) == 0 ){
								
				//gameMechanics.SwitchPauseResume();
										
							}
					}
			}
	
	}