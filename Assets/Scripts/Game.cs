using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private static Game current;

	private int score;
	private string level;

	void Start(){
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

}
