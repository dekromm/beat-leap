using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	private static Game current;

	private string level;

	void Start(){
		if(current == null){
			current = this;
			DontDestroyOnLoad(current);
		}
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

}
