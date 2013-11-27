using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics
{

	private Beat beat;
	private BeatTimings beatManager;
	private bool isGamePlaying;
	private GameField gameField;
	private Timer timer;
	private double interval;

	public GameMechanics(string src)
	{

		//gameField = new GameField(src);

		beatManager = new BeatTimings(src);

		interval = 10;

		Config config = (Config) GameObject.Find("Config").GetComponent("Config");
		GameObject beatPrefab = config.beatPrefab;
		beat = (Beat) ((GameObject) GameObject.Instantiate(beatPrefab)).GetComponent("Beat");

	
	}

	//metodo chiamato quando parte il livello
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

			// gameField.aggiorna_il_piano_di_gioco

			// aggiorno la view
		}*/
	}

	#region userInput
	public void MoveUp()
	{
		Debug.Log("Move UP");
	}

	public void MoveDown()
	{
		Debug.Log("Move DOWN");
	}

	public void MoveLeft()
	{
		Debug.Log("Move LEFT");
	}

	public void MoveRight()
	{
		Debug.Log("Move RIGHT");
	}

	public void SwitchPauseResume()
	{

		isGamePlaying = beatManager.SwitchAudioPlayStop();

		if (isGamePlaying) {
			timer.Stop();
			Debug.Log("PAUSE");
		} else {
			timer.Start();
			Debug.Log("RESUME");
		}
	}
	#endregion

	private void Move(Vector2 direction)
	{

		//controlli sul movimento del beat

		//aggiornamento della posizione del beat

	}


}
