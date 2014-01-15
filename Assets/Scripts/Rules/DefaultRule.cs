using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefaultRule: Rule {


	#region GameField aimed Methods

	public override Rule Step(List<Cube> field, ref LevelMap map, Beat beat){
		Rule nextRule = this;
		Cube toDestroy = null;
		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if(IsEnemy(c)){
					SoundEffectManager.main.PlayHit();
					// beat.score - 100 ???
				} else if (IsItem(c)) {

					nextRule = ( (Item) c ).rule;
					toDestroy = c;
					c.Recycle();
				} else if (IsMoney(c)) {
					int num = ((Money) c).amount;
					beat.setScore(num);
					beat.FlyPoints(num);
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
		return nextRule;
	}
		
#endregion

}
