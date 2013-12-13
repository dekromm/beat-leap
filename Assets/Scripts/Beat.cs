using UnityEngine;
using System.Collections;

public class Beat : Cube
{

	int score = 1000;
	string message;
	int multiplier = 1;
	int rightSequences = 0;

	Config.Command currentCommand = Config.Command.NULL;

	public const int thresholdMultiplier = 4;

	public Rule powerup = new Rule();
	int moveMagnitude = 1;
	int damage;

	public Vector2 Move(Vector2 direction)
	{
		Vector2 next = logicPosition + direction;

		if(!isOutOfRange(next)){
			SetDirection(direction.x, direction.y);
			return Move();
		}

		return logicPosition;
	}

	public void PushCommand(Config.Command command, int score, bool maxPrecision){
		if(command == Config.Command.HIT){

			currentCommand = command;
			ResetStat ();
			//this.score -= score*multiplier*powerup.getBaseMultiplier();

		}else{
			    currentCommand = command;
				UpgradeStat();
				int baseMultiplier = powerup.getBaseMultiplier ();
				this.score += score * multiplier * baseMultiplier;
				if(maxPrecision)
					message = Config.Messages.LikeAGod();
				else
					message = Config.Messages.Good();
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

		if(rightSequences>=0)
			rightSequences++;
		else
			rightSequences=1;

		multiplier = rightSequences / thresholdMultiplier + 1;

	}

	public string GetScore(){

		return score.ToString();
	}

	public string GetMessage(){
		
		return message;
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
				message = Config.Messages.Async();
			}break;
			case Config.Command.NULL:{
				ResetStat ();		
				this.score -= 10;
				message = Config.Messages.Miss();
			}break;
		}

		currentCommand = Config.Command.NULL;
	}

	bool isOutOfRange(Vector2 next)
	{
		float x = next.x;
		float y = next.y;

		if( x<0 || x>=Config.Logic.GridLength() || y<0 || y>=Config.Logic.GridDepth() )
			return true;
		return false;
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
