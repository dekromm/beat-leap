using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * When enabled, the beat detonates all the enemy in the scene
 */

public class Detonation : Rule
{
	
	private int duration = 1;
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
					SoundEffectManager.main.PlayHit();
				} else if (IsItem(c)) {
					if(IsDetonation(( (Item) c ).rule)){
						haveToDestroyAll=true;
						//put a sound for the explosion!!!!not here...
					}
					nextRule = ((Item)c).rule;
					toDestroy = c;
					c.Recycle();
				} else if (IsMoney(c)) {
					GetPointsFromMoney(c,beat);
					toDestroy = c;
					c.Recycle();
				} 
			}
		}

		if (haveToDestroyAll) {
			field = DestroyThemAll(field);//...but here
		}

		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		
		AddRows(map, field);
				
		return nextRule;
	}

	public override void GetPointsFromMoney (Cube c, Beat beat)
	{
		int num = ((Money)c).amount;
		beat.setScore (num);
		beat.FlyPoints (num);
	}


}
