using UnityEngine;
using System.Collections;

public class Beat : Cube
{

	int health;
	Config.Command currentCommand = Config.Command.NULL;

	public Beat(){
		health = 100;
	
	}



	public void PushCommand(Config.Command command){
		if(command == Config.Command.HIT){
			// E' arrivato un PICCHIATI
			health--;
		}else{
			if(currentCommand == Config.Command.NULL){
				currentCommand = command;
			}else{
				// Qui invece mi picchio da solo perche' stanno arrivando troppi spostamenti
				health--;
			}
		}
		Debug.Log(command);
	}

	public void CommitCommand(){

		switch(currentCommand){
			case Config.Command.DOWN:{
				Move(Config.Direction.Down());
			}break;
			case Config.Command.UP:{
				Move(Config.Direction.Up());
			}break;
			case Config.Command.RIGHT:{
				Move(Config.Direction.Right());
			}break;
			case Config.Command.LEFT:{
				Move(Config.Direction.Left());
			}break;
		}

		// gestisci comando
		currentCommand = Config.Command.NULL;
	}
}
