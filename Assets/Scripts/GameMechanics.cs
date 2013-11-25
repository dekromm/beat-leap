using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics{

	private Beat beat;
	private BeatTimings beatManager;
	private bool isGamePlaying;

	private GameField gameField;

	private Timer timer;
	private double interval;

	public GameMechanics(string src){

		gameField = new GameField(src);

		beatManager = new BeatTimings(src);

//		beat = new Beat();
	}

	//metodo chiamato quando parte il livello
	public void StartPlaying(){

		timer = new Timer(interval);
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		timer.Enabled = true;
	}

	private void OnTimedEvent(object source, ElapsedEventArgs e)
	{

		if( beatManager.HasBeatPassed () ){

			// gameField.aggiorna_il_piano_di_gioco

			// aggiorno la view
		}
	}

	#region userInput
	public void MoveUp(){


		//Move(vec direzione);
	}

	public void MoveDown(){

		//Move(vec direzione);
	}

	public void MoveLeft(){

		//Move(vec direzione);
	}

	public void MoveRight(){

		//Move(vec direzione);
	}

	public void SwitchPauseResume(){

		isGamePlaying = beatManager.SwitchAudioPlayStop();

		if(isGamePlaying)
			timer.Stop();
		else
			timer.Start();
	}
	#endregion

	private void Move(Vector2 direction){

		//controlli sul movimento del beat

		//aggiornamento della posizione del beat

	}


}
