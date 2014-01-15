using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Rule
{

	private int duration=3;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, ref LevelMap map, Beat beat)
	{
		Debug.Log("Shielded!");
		if (duration > 0) {
			nextRule = this;
		} else {
			nextRule = new DefaultRule();
		}
		
		beat.CommitCommand();
		Cube toDestroy = null;;
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					duration--;
					SoundEffectManager.main.PlayHit();
				} else if (IsItem(c)) {
					nextRule = ((Item)c).rule;
					c.Recycle();
					toDestroy = c;
				} 
			}
		}
		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		return nextRule;
	}
}
