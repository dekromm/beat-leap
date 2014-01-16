using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shield : Rule
{

	private int duration=3;
	private Rule nextRule;
	
	public override Rule Step(List<Cube> field, ref LevelMap map, ref Beat beat)
	{
		Debug.Log("Shielded!");
		if (duration > 0) {
			nextRule = this;
		} else {
			nextRule = new DefaultRule();
		}
		bool haveToDestroyAll=false;
		beat.CommitCommand();
		Cube toDestroy = null;;
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if (IsEnemy(c)) {
					duration--;
					SoundEffectManager.main.PlayShield();
				} else if (IsItem(c)) {
					if(IsDetonation(( (Item) c ).rule)){
						haveToDestroyAll=true;
					}
					nextRule = ((Item)c).rule;
					c.Recycle();
					toDestroy = c;
				}  else if (IsMoney(c)) {
					GetPointsFromMoney(c,beat);
					toDestroy = c;
					c.Recycle();
				} 
			}
		}

		if (haveToDestroyAll) {
			field = DestroyThemAll(field);
			SoundEffectManager.main.PlayExplosion();
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
