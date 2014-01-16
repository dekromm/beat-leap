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
		private bool isNotDown;

//	const KeyCode UP = KeyCode.UpArrow;
//	const KeyCode DOWN = KeyCode.DownArrow;
//	const KeyCode RIGHT = KeyCode.RightArrow;
//	const KeyCode LEFT = KeyCode.LeftArrow;
//	const KeyCode PAUSE = KeyCode.Space;

	
		// Use this for initialization
		void Start ()
		{
				string levelName = Game.Current ().Level ();
				gameMechanics = new GameMechanics (levelName);
				this.SwitchPauseResume ();
				Input.GetAxis ("Horizontal");
				isNotDown = true;
		}
        
		// Update is called once per frame
		void Update ()
		{
		}
        
		// OnGUI is called once for every event in unity
		// this means it is frame-indepent, making it the right place
		// where to put the input capture. Maybe.
		void OnGUI ()
		{
				if (Event.current.type.Equals (EventType.KeyDown) && isNotDown) {

						isNotDown = false;

						float vertical = Input.GetAxis ("Vertical");
						float horizontal = Input.GetAxis ("Horizontal");
						float pause = Input.GetAxis ("Pause");
						
						if (gameMechanics.isGamePlaying) {
								//	if (Event.current.keyCode.CompareTo (UP) == 0) {
								if (vertical < 0) {
                
										gameMechanics.MoveUp ();
                        
								} else if (vertical > 0) {
                
										gameMechanics.MoveDown ();
                        
								} else if (horizontal < 0) {
                
										gameMechanics.MoveLeft ();
                        
								} else if (horizontal > 0) {
                                
										gameMechanics.MoveRight ();
                                        
								}
						}
						if (pause == 1)                
								SwitchPauseResume ();                                        

				}
				if (Event.current.type.Equals (EventType.KeyUp))
						isNotDown = true;
		}

		public void SwitchPauseResume ()
		{

				if (!gameMechanics.isGamePlaying) {
						StartTimer ();
				} else
						stopTimer ();
		
				//GameMechanics.StartPlaying();
		
				gameMechanics.SwitchPauseResume ();

		}

		private void StartTimer ()
		{

				InvokeRepeating ("CheckBeat", 0, 0.001f);

		}

		public void GameOver(){
			stopTimer();
			gameMechanics.GameOver();
			Invoke("GameOverScene",4.0f);
		}

		public void GameOverScene(){
			Application.LoadLevel("GameOver");
		}

		public void stopTimer ()
		{

				CancelInvoke ("CheckBeat");

		}

		private void CheckBeat ()
		{

				gameMechanics.CheckBeat ();
			
		}
    
}