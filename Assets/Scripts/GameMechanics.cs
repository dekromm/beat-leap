using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics
{
	private BeatTimings beatManager;
	private GameField gameField;
	public bool isGamePlaying;

	// Giusto per stare col culo nel burro
	private Timer timer;
	private double interval;

	private const int scoreLow = 10;
	private const int scoreHigh = 50;

	GameObject accuracyCube;

	TimeLine timeLine;

	public GameMechanics(string src)
	{
		accuracyCube = GameObject.Find("AccuracyCube");

		gameField = new GameField(src);
		beatManager = new BeatTimings(src);
		timeLine = new TimeLine(beatManager.GetTimings());
		TimeLine.isActive = false;

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
	
	public void CheckBeat()
	{
		accuracyCube.gameObject.transform.position = new Vector3(-75+75*2*beatManager.GetAccuracy(),0,45);
		if (beatManager.HasBeatPassed()) {
			Debug.Log("BEAT");
			gameField.StepUpdate();
		}
		timeLine.FireSticks(beatManager.GetTime());
	}

	#region userInput
	public void MoveUp()
	{
		Move(Config.Command.UP);
	}

	public void MoveDown()
	{
		Move(Config.Command.DOWN);
	}

	public void MoveLeft()
	{
		Move(Config.Command.LEFT);
	}

	public void MoveRight()
	{
		Move(Config.Command.RIGHT);
	}

	public void SwitchPauseResume()
	{

		isGamePlaying = beatManager.SwitchAudioPlayStop();
		TimeLine.isActive = isGamePlaying;

		if (isGamePlaying) {

			Debug.Log("PAUSE");
		} else {

			Debug.Log("RESUME");
		}
	}
	#endregion

	private void Move(Config.Command command)
	{
		float accuracy = beatManager.GetAccuracy();
		if( accuracy >=0 ){
			if (accuracy < beatManager.deltaTime/2)
				gameField.CommandToBeat(command, scoreHigh);
			else 
				gameField.CommandToBeat(command, scoreLow);
		}else{
			gameField.CommandToBeat(Config.Command.HIT, 0); // passo 0, in quanto l'argomento è irrilevante
		}

	}

}
