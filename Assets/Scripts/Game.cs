using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private static Game current;

	private int score;
	private int maxCombo; // combo di beat consecutivi più lunga
	private int length; //lunghezza della traccia, in termini di beat
	private int catchedBeats; //beat presi
	private string level;
	public bool isMobile;
	public bool swipeInput;

	public string gameScene;

	void Start(){
		isMobile = false;
		gameScene = "Game";
		#if UNITY_IOS
		isMobile = true;
		gameScene = "Game_4_3";
		#endif
		swipeInput = false;
		if(current == null){
			current = this;
			DontDestroyOnLoad(current);
		}

		score = 0;
	}

	public static Game Current(){
		return current;
	}

	public void SetLevel(string nextLevel){
		current.level = nextLevel;
	}

	public string Level(){
		return level;
	}

	public void setScore(int score){
		current.score = score;		
	}

	public int Score(){
		return score;
	}

	public void setMaxCombo(int combo){
		current.maxCombo = combo;		
	}

	public int MaxCombo(){
		return maxCombo;
	}

	public void setCatchedBeats(int cbeats){
		current.catchedBeats = cbeats;		
	}
	
	public int CatchedBeats(){
		return catchedBeats;
	}

	public void setLength(int length){
		current.length = length;		
	}
	
	public int Length(){
		return length;
	}

}
