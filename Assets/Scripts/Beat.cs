using UnityEngine;
using System.Collections;

public class Beat : Cube
{

	int health;
	Config.Command currentCommand = Config.Command.NULL;

	public Rule  powerup;
	int moveMagnitude:
	int damage;

	public Beat(){
		health = 100;
	
	}

	public void newPowerUp(Rule r){
		
		moveMagnitude = r.getBeatMagnitude();
		damage = r.getDamage();

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
				Move(Config.Direction.Down()*moveMagnitude);
			}break;
			case Config.Command.UP:{
				Move(Config.Direction.Up()*moveMagnitude);
			}break;
			case Config.Command.RIGHT:{
				Move(Config.Direction.Right()*moveMagnitude);
			}break;
			case Config.Command.LEFT:{
				Move(Config.Direction.Left()*moveMagnitude);
			}break;
		}

		// gestisci comando
		currentCommand = Config.Command.NULL;
	}
}
