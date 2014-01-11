using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics
{
		private BeatTimings beatManager;
		private GameField gameField;
		public bool isGamePlaying;
		public bool isGameStarted;

		// Giusto per stare col culo nel burro
		private Timer timer;
		private double interval;
		private const int scoreLow = 10;
		private const int scoreHigh = 50;
		GameObject accuracyCube;
		TimeLine timeLine;
		private GameObject pauseScreen;
		//private GameObject mainCamera;
		private TextMesh state;

		public GameMechanics (string src)
		{
				accuracyCube = GameObject.Find ("AccuracyCube");

				gameField = new GameField (src);
				beatManager = new BeatTimings (src);
				timeLine = new TimeLine (beatManager.GetTimings ());
				TimeLine.isActive = false;
		
				//	mainCamera = GameObject.Find("Main Camera");

				pauseScreen = GameObject.FindGameObjectWithTag ("PauseScreen");
				isGameStarted = false;
				isGamePlaying = false;

				state = (TextMesh)GameObject.Find ("State").GetComponent<TextMesh> ();

		}

		public void StartPlaying ()
		{
		
				timer = new Timer (interval);
				timer.Elapsed += new ElapsedEventHandler (OnTimedEvent);
				timer.Enabled = true;
		}

		private static void OnTimedEvent (object source, ElapsedEventArgs e)
		{
				Debug.Log ("check");
				/* Attenzione: non si può usare un oggetto non statico in un metodo statico
					if( beatManager.HasBeatPassed () ){
			
							Debug.Log("BEAT");

							if(isBeatAlreadyMoved)
									beat.Move(direction);

							isBeatAlreadyMoved = false;
                }*/
		}
	
		public void CheckBeat ()
		{
				//accuracyCube.gameObject.transform.position = new Vector3(-75 + 75 * 2 * beatManager.GetAccuracy(), 0, 45);

				if (beatManager.HasBeatPassed ()) {							
						gameField.StepUpdate ();
				}

				if (beatManager.IsOver ())
						GameOver ();

				timeLine.FireSticks (beatManager.GetTime ());
		}

	#region userInput
		public void MoveUp ()
		{
				Move (Config.Command.UP);
		}

		public void MoveDown ()
		{
				Move (Config.Command.DOWN);
		}

		public void MoveLeft ()
		{
				Move (Config.Command.LEFT);
		}

		public void MoveRight ()
		{
				Move (Config.Command.RIGHT);
		}

		public void SwitchPauseResume ()
		{

				isGamePlaying = beatManager.SwitchAudioPlayStop ();
				TimeLine.isActive = isGamePlaying;

				if (!isGamePlaying) {
						SetState ("Paused");
						WatchScoreboard ();
				} else {
						SetState ("Playing");
						WatchGame ();
				}
		}
	#endregion

		private void Move (Config.Command command)
		{
				float accuracy = beatManager.GetAccuracy ();
				if (accuracy >= 0) {
						if (!gameField.alreadyGetIt) {

								gameField.alreadyGetIt = true; 

								if (accuracy < beatManager.deltaTime / 2)
										gameField.CommandToBeat (command, scoreHigh, true);
								else 
										gameField.CommandToBeat (command, scoreLow, false);
						}
				} else {
						gameField.CommandToBeat (Config.Command.MISS, 0, false); // passo 0, in quanto l'argomento è irrilevante
				}

		}

		private void GameOver ()
		{
				SetState ("Game Over");
				Game.Current().setScore (gameField.currentScore ());
				System.Threading.Thread.Sleep(2000);
				Application.LoadLevel("GameOver");
		}

		private void SetState (string state)
		{
				this.state.text = state;
		}

		private void WatchScoreboard ()
		{
				//	mainCamera.transform.localEulerAngles = new Vector3(-3.0f,0,0);
				pauseScreen.transform.position += new Vector3 (0, -1000, 0);
		}

		private void WatchGame ()
		{
				//mainCamera.transform.localEulerAngles = new Vector3(55.0f,0,0);
				if (isGameStarted)
						pauseScreen.transform.position += new Vector3 (0, 1000, 0);
				isGameStarted = true;
			
		}

}
