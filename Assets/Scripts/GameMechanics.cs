using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics
{

	private Beat beat;
	private Vector2 direction = new Vector2 (0,0);

	private BeatTimings beatManager;

	private GameField gameField;

	private Timer timer;
	private double interval;

	public bool isGamePlaying;
	private bool isBeatAlreadyMoved = false;

	public GameMechanics(string src)
	{

		//gameField = new GameField(src);

		beatManager = new BeatTimings(src);

		interval = 10;

		Config config = (Config) GameObject.Find("Config").GetComponent("Config");
		GameObject beatPrefab = config.beatPrefab;
		beat = (Beat) ((GameObject) GameObject.Instantiate(beatPrefab)).GetComponent("Beat");

//		beat.SetPosition(2,3);

	}

	public void StartPlaying()
	{
		
		timer = new Timer(interval);
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		timer.Enabled = true;
	}

	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		Debug.Log("check");
		/* Attenzione: non si può usare un oggetto non statico in un metodo statico
					if( beatManager.HasBeatPassed () ){
			
							Debug.Log("BEAT");

							if(isBeatAlreadyMoved)
									beat.Move(direction);

							isBeatAlreadyMoved = false;
                }*/
	}
	
	public void CheckBeat(){
		
		if( beatManager.HasBeatPassed () ){
			
			Debug.Log("BEAT");

			if(isBeatAlreadyMoved)
				beat.Move(direction);

			isBeatAlreadyMoved = false;
			
		}
	}

	#region userInput
	public void MoveUp()
	{
		Vector2 direction = new Vector2(0,-1);
		Move(direction);
//		Debug.Log("Move UP");
	}

	public void MoveDown()
	{
		Vector2 direction = new Vector2(0,1);
		Move(direction);
//		Debug.Log("Move DOWN");
	}

	public void MoveLeft()
	{
		Vector2 direction = new Vector2(-1,0);
		Move(direction);
//		Debug.Log("Move LEFT");
	}

	public void MoveRight()
	{
		Vector2 direction = new Vector2(1,0);
		Move(direction);
//		Debug.Log("Move RIGHT");
	}

	public void SwitchPauseResume()
	{

		isGamePlaying = beatManager.SwitchAudioPlayStop();

		if (isGamePlaying) {

			Debug.Log("PAUSE");
		} else {

			Debug.Log("RESUME");
		}
	}
	#endregion

//	movimento con precisione massima (senza controllo sul beat)
//	private void Move(Vector2 direction){
//
//		beat.Move(direction);
//	}

	private void Move(Vector2 direction)
	{

		if(!isBeatAlreadyMoved){

			isBeatAlreadyMoved=true;
			this.direction = direction; //imposto la direzione del movimento
										// N.B. il movimento avviene solo in concomitanza con
										// 		beatManager.hasBeatPassed()... però si crea un 
		
		}else{

			//più di un movimento per beat è un errore e
			//bisogna decrementare il punteggio o la salute

		}
	}

}
