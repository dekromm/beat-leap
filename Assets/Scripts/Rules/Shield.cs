using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Rule
{

	private int duration;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, LevelMap map, Beat beat)
	{
		Debug.Log("Shielded!");
		if (duration > 0) {
			nextRule = this;
		} else {
			nextRule = new DefaultRule();
		}
		
		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					duration--;
				} else if (IsItem(c)) {
					nextRule = ((Item)c).rule;
				} 
			}
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		return nextRule;
	}
}
