﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Combo boost: for a limitet amount of beats you can increase your combo
 * and raise your score faster.
 */
public class ComboBoost : Rule
{
	
	private int duration = 7;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, LevelMap map, Beat beat)
	{
		if (duration > 0) {
			if (duration == 7) {
				//è la prima step
				beat.SetBaseMultiplier(2);
			}
			nextRule = this;
			duration--;
		} else {
			nextRule = new DefaultRule();
		}
		
		beat.CommitCommand();
		//	beat.PauseInput();
		Cube enemyToDestroy = null;
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					c.Recycle();
					enemyToDestroy = c;
				} else if (IsItem(c)) {
					nextRule = ((Item)c).rule;
				} 
			}
		}
		if (enemyToDestroy != null) {
			field.Remove(enemyToDestroy);
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		if (nextRule != this) {
			//è la ultima step
			beat.SetBaseMultiplier(1);
		}
		return nextRule;
	}
}