using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Combo boost: for a limitet amount of beats you can increase your combo
 * and raise your score faster.
 */
public class ComboBoost : Rule
{
	
	private int duration = 15;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, ref LevelMap map, Beat beat)
	{
		if (duration > 0) {
			if (duration == 15) {
				//è la prima step
				beat.SetBaseMultiplier(2);
			}
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
				if(IsEnemy(c)){
					SoundEffectManager.main.PlayHit();
					beat.PushCommand(Config.Command.DAMAGE, 0, false);
					c.Recycle();
					toDestroy = c;
					nextRule = new DefaultRule();
				} else if (IsItem(c)) {
					if(IsDetonation(( (Item) c ).rule)){
						haveToDestroyAll=true;
						//put a sound for the explosion!!!!
					}
					nextRule = ( (Item) c ).rule;
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
			field = DestroyThemAll(field);
		}

		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		if (nextRule != this) {
			//è la ultima step
			beat.SetBaseMultiplier(1);
		}
		return nextRule;
	}

	public override void GetPointsFromMoney (Cube c, Beat beat)
	{
		int num = ((Money)c).amount;
		beat.setScore (num);
		beat.FlyPoints (num);
	}
}
