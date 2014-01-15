﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * When enabled, the beat always leap by 2 squares each time.
 * If you're close to the edge, it'll jump avoiding to fall off.
 */

public class DoubleMovement : Rule
{
	
	private int duration = 7;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, ref LevelMap map, Beat beat)
	{
		if (duration > 0) {
			if(duration == 7){
				//è la prima step
				beat.SetMagnitude(2);
			}
			nextRule = this;
			duration--;
		} else {
			nextRule = new DefaultRule();
		}
		
		beat.CommitCommand();
		//	beat.PauseInput();
		Cube toDestroy = null;
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					SoundEffectManager.main.PlayHit();
				} else if (IsItem(c)) {
					nextRule = ((Item)c).rule;
					toDestroy = c;
					c.Recycle();
				} 
			}
		}
		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		if(nextRule != this){
			//è la ultima step
			beat.SetMagnitude(1);
		}
		return nextRule;
	}
}
