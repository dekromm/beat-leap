using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Invincibility: in this state if you hit an obstacle you destroy it!
 * This power only lasts for a @duration numer of beats
 */
public class Invincibility : Rule{
	
	private int duration = 15;
	private Rule nextRule;

	public override Rule Step(List<Cube> field, LevelMap map, Beat beat)
	{
		if (duration > 0) {
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
					SoundEffectManager.main.PlayDestrucion();
					c.Recycle();
					toDestroy = c;
					beat.PushCommand(Config.Command.ATTACK,0,false);
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
