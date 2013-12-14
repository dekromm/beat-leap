using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
	public GameMechanics gameMechanics;
	const KeyCode UP = KeyCode.W;
	const KeyCode DOWN = KeyCode.S;
	const KeyCode RIGHT = KeyCode.D;
	const KeyCode LEFT = KeyCode.A;
	const KeyCode PAUSE = KeyCode.Space;

//	const KeyCode UP = KeyCode.UpArrow;
//	const KeyCode DOWN = KeyCode.DownArrow;
//	const KeyCode RIGHT = KeyCode.RightArrow;
//	const KeyCode LEFT = KeyCode.LeftArrow;
//	const KeyCode PAUSE = KeyCode.Space;

	
	// Use this for initialization
	void Start()
	{
		string levelName = Game.Current().Level();
		gameMechanics = new GameMechanics(levelName);

	}
        
	// Update is called once per frame
	void Update()
	{
	}
        
	// OnGUI is called once for every event in unity
	// this means it is frame-indepent, making it the right place
	// where to put the input capture. Maybe.
	void OnGUI()
	{
		if (Event.current.type.Equals(EventType.KeyDown)) {
			if (Event.current.keyCode.CompareTo(UP) == 0) {
                
				gameMechanics.MoveUp();
                        
			} else if (Event.current.keyCode.CompareTo(DOWN) == 0) {
                
				gameMechanics.MoveDown();
                        
			} else if (Event.current.keyCode.CompareTo(LEFT) == 0) {
                
				gameMechanics.MoveLeft();
                        
			} else if (Event.current.keyCode.CompareTo(RIGHT) == 0) {
                                
				gameMechanics.MoveRight();
                                        
			} else if (Event.current.keyCode.CompareTo(PAUSE) == 0) {
                
				SwitchPauseResume();
                                        
			}
		}
	}

	public void SwitchPauseResume(){

		if (!gameMechanics.isGamePlaying) {
			startTimer();
		} else
			stopTimer();
		
		//GameMechanics.StartPlaying();
		
		gameMechanics.SwitchPauseResume();

	}

	private void startTimer()
	{

		InvokeRepeating("CheckBeat", 0, 0.0002f);

	}

	private void stopTimer()
	{

		CancelInvoke("CheckBeat");

	}

	private void CheckBeat()
	{

		gameMechanics.CheckBeat();
			
	}
    
}