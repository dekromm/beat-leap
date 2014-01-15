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

	public override Rule Step(List<Cube> field, ref LevelMap map, Beat beat)
	{
		if (duration > 0) {
			nextRule = this;
			duration--;
		} else {
			nextRule = new DefaultRule();
		}
		bool haveToDestroyAll=false;
		beat.CommitCommand();
		//	beat.PauseInput();
		Cube toDestroy = null;
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					c.Recycle();
					SoundEffectManager.main.PlayDestrucion();
					toDestroy = c;
				} else if (IsItem(c)) {
					if(IsDetonation(( (Item) c ).rule)){
						haveToDestroyAll=true;
						//put a sound for the explosion!!!!
					}
					nextRule = ((Item)c).rule;
					c.Recycle();
					toDestroy = c;
				} else if (IsMoney(c)) {
					GetPointsFromMoney(c,beat);
					toDestroy = c;
					c.Recycle();
				} 
			}
		}

		if (haveToDestroyAll) {
			field = DestroyThemAll(field);
		}

		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		return nextRule;
	}

	public override void GetPointsFromMoney (Cube c, Beat beat)
	{
		int num = ((Money)c).amount;
		beat.setScore (num);
		beat.FlyPoints (num);
	}

}
