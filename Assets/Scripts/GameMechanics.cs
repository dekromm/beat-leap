﻿using UnityEngine;
using System.Collections;
using System.Timers;

public class GameMechanics
{
	private BeatTimings beatManager;
	private GameField gameField;
	public bool isGamePlaying;
	public bool isGameStarted;
	public bool stepped;

	// Giusto per stare col culo nel burro
	private Timer timer;
	private double interval;
	private const int scoreLow = 10;
	private const int scoreHigh = 50;
	TimeLine timeLine;
	private GameObject pauseScreen;
	//private GameObject mainCamera;
	private TextMesh state;
	private BeatLight beatLight;

	public GameMechanics(string src)
	{
		gameField = new GameField(src);
		beatManager = new BeatTimings(src);
		timeLine = new TimeLine(beatManager.GetTimings());
		TimeLine.isActive = false;
		
		//	mainCamera = GameObject.Find("Main Camera");

		pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
		isGameStarted = false;
		isGamePlaying = false;
			
		state = (TextMesh)GameObject.Find("State").GetComponent<TextMesh>();
		if (GameObject.Find("BeatLight")) {
			beatLight = GameObject.Find("BeatLight").GetComponent<BeatLight>()as BeatLight;
		}
				
	}

	public void CheckBeat()
	{
		if (beatManager.HasBeatPassed()) {
			if (stepped) {
				stepped = false;
			} else {
				gameField.StepUpdate();
				if(beatLight!=null){
					beatLight.Flash();
				}
			}
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
		if (isGameStarted) {
			SoundEffectManager.main.PauseResume(isGamePlaying);
		}

		if (!isGamePlaying) {
			SetState("Paused");
			WatchScoreboard();
		} else {
			SetState("Playing");
			WatchGame();
		}
	}
	#endregion

	private void Move(Config.Command command)
	{
		float accuracy = beatManager.GetAccuracy();
		if (accuracy >= 0) {

			if (!stepped) {

				stepped = true; 

				if (accuracy < beatManager.deltaTime / 2)
					gameField.CommandToBeat(command, scoreHigh, true);
				else 
					gameField.CommandToBeat(command, scoreLow, false);
				
				gameField.StepUpdate();
			}

		} else {
			gameField.CommandToBeat(Config.Command.MISS, 0, false); // passo 0, in quanto l'argomento è irrilevante
		}
	}

	public void GameOver()
	{
		SetState("Game Over");
		gameField.SendStatistics ();
	}

	private void SetState(string state)
	{
		this.state.text = state;
	}

	private void WatchScoreboard()
	{
		pauseScreen.transform.position += new Vector3(0, -1000, 0);
	}

	private void WatchGame()
	{
		if (isGameStarted)
			pauseScreen.transform.position += new Vector3(0, 1000, 0);
		isGameStarted = true;			
	}

}
