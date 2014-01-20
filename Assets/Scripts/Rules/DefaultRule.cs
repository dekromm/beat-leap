using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefaultRule: Rule {


	#region GameField aimed Methods

	public override Rule Step(List<Cube> field, ref LevelMap map, ref Beat beat){
		Rule nextRule = this;
		Cube toDestroy = null;
		bool haveToDestroyAll=false;
		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if(IsEnemy(c)){
					SoundEffectManager.main.PlayHit();
					beat.PushCommand(Config.Command.DAMAGE, 0, false);
					c.Recycle();
					toDestroy = c;
				} else if (IsItem(c)) {
					if(IsDetonation(( (Item) c ).rule)){
						beat.PushCommand(Config.Command.DESTROY,GetPointsOverDestruction(field),false);
						haveToDestroyAll=true;
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
			SoundEffectManager.main.PlayExplosion();
		}

		if (toDestroy != null) {
			field.Remove(toDestroy);
		}
		AddRows(map, field);
		//beat.UnPauseInput();
		return nextRule;
	}
		
#endregion

	public override void GetPointsFromMoney (Cube c, Beat beat)
	{
		int num = ((Money)c).amount;
		beat.setScore (num);
		beat.FlyPoints (num);
		SoundEffectManager.main.PlayMoney();
	}

}
