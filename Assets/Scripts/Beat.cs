using UnityEngine;
using System.Collections;

public class Beat : Cube
{
	int multiplier = 1;
	int rightSequences = 0;
	public const int thresholdMultiplier = 8;
	private int score;
	private string message;
	private int baseMultiplier = 1;
	Config.Command currentCommand = Config.Command.NULL;
	int moveMagnitude = 1;
	int damage;
	private Emitter emitter;

	void Start()
	{
		emitter = GameObject.Find("BeatEmitter").GetComponent("Emitter") as Emitter;
		emitter.FollowBeat(gameObject.transform.position);
	}

	public Vector2 Move(Vector2 direction)
	{
		Vector2 next = logicPosition + direction;

		if (!isOutOfRange(next)) {
			SetDirection(direction.x, direction.y);
			next = Move();
			emitter.FollowBeat(gameObject.transform.position);
			return next;
		}

		return logicPosition;
	}

	public void PushCommand(Config.Command command, int score, bool maxPrecision)
	{


		int nextScore;
		if (command == Config.Command.MISS) {
			
			ResetStat();
			
			this.score -= 50 * multiplier * baseMultiplier;
			message = Config.Messages.Async();
			
			emitter.PlayBad();
		} else if (command == Config.Command.DAMAGE) {
			
			ResetStat();
			
			this.score -= 300 * multiplier * baseMultiplier;
			message = Config.Messages.Bad();
			
			emitter.PlayBad();
		} else {
			currentCommand = command;
			UpgradeStat();
				
			this.score += score * multiplier * baseMultiplier;
			if (maxPrecision) {
				message = Config.Messages.LikeAGod();
				emitter.PlayGod();
			} else {
				message = Config.Messages.Good();
				emitter.PlayGood();
			}
		}

	}

	#region score
	void ResetStat()
	{

		multiplier = 1;

		if (rightSequences > 1)
			rightSequences = 0;
		else
			rightSequences--;

	}

	void UpgradeStat()
	{

		if (rightSequences >= 0)
			rightSequences++;
		else
			rightSequences = 1;

		multiplier = rightSequences / thresholdMultiplier + 1;

	}
	
	#endregion

	public void CommitCommand()
	{

		switch (currentCommand) {
			case Config.Command.DOWN:
				{
					for (int i=0; i< moveMagnitude; i++) {
						Move(Config.Direction.Down());
					}
				}
				break;
			case Config.Command.UP:
				{
					for (int i=0; i< moveMagnitude; i++) {
						Move(Config.Direction.Up());
					}
				}
				break;
			case Config.Command.RIGHT:
				{
					for (int i=0; i< moveMagnitude; i++) {
						Move(Config.Direction.Right());
					}
				}
				break;
			case Config.Command.LEFT:
				{
					for (int i=0; i< moveMagnitude; i++) {
						Move(Config.Direction.Left());
					}
				}
				break;
			case Config.Command.NULL:
				{
					ResetStat();		
					//score -= 10;
					message = Config.Messages.Miss();
					emitter.PlayBad();
				}
				break;
		}

		currentCommand = Config.Command.NULL;
	}

	bool isOutOfRange(Vector2 next)
	{
		float x = next.x;
		float y = next.y;

		if (x < 0 || x >= Config.Logic.GridLength() || y < 0 || y >= Config.Logic.GridDepth())
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

	#region getters
	public int getScore()
	{

		return score;
	}

	public string getMessage()
	{

		return message;
	}

	public int getMultiplier()
	{

		return multiplier * baseMultiplier;
	}
	#endregion

	#region beat modifiers
	
	public void SetDamage(int d)
	{
		damage = d;
	}
	
	public void SetMagnitude(int m)
	{
		moveMagnitude = m;
	}
	
	public void SetBaseMultiplier(int m)
	{
		baseMultiplier = m;
	}
	#endregion
}
