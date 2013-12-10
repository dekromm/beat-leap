using UnityEngine;
using System.Collections;

public class Beat : Cube
{

	int score = 1000;
	int multiplier = 1;
	int rightSequences = 0;

	Config.Command currentCommand = Config.Command.NULL;

	public const int thresholdMultiplier = 4;

	public Rule powerup = new Rule();
	int moveMagnitude = 1;
	int damage;

	public void PushCommand(Config.Command command, int score){
		if(command == Config.Command.HIT){

			currentCommand = command;
			ResetStat ();
			//this.score -= score*multiplier*powerup.getBaseMultiplier();

		}else{
			    currentCommand = command;
				UpgradeStat();
				int baseMultiplier = powerup.getBaseMultiplier ();
				this.score += score * multiplier * baseMultiplier;
			}

		Debug.Log(command);
	}

	#region score
	void ResetStat (){

		multiplier = 1;

		if(rightSequences>1)
			rightSequences = 0;
		else
			rightSequences--;

	}

	void UpgradeStat (){

		rightSequences++;

		multiplier = rightSequences / thresholdMultiplier + 1;

	}

	public string GetScore(){

		return score.ToString();
	}
	#endregion

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
			case Config.Command.HIT:{
				this.score -= 50;
			}break;
			case Config.Command.NULL:{
				ResetStat ();		
				this.score -= 10;
			}break;
		}

		currentCommand = Config.Command.NULL;
	}
	
	public bool Collided(Cube c)
	{
		if (c.logicPosition.Equals(logicPosition)) {
			return true;
		} else {
			return false;
		}
		return false;
	}
	#region beat modifiers

	public void NewPowerUp(Rule rule){

		powerup = rule;
	}
	
	public void SetDamage(int d){
		damage = d;
	}
	
	public void SetMagnitude(int m){
		moveMagnitude = m;
	}
	#endregion
}
