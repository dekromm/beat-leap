using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefaultRule: Rule {


	#region GameField aimed Methods

	public override Rule Step(List<Cube> field, LevelMap map, Beat beat){
		Rule nextRule = this;

		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				if(IsEnemy(c)){
					// beat.score - 100 ???
				} else if (IsItem(c)) {
					// ((Item) c ).rule.immediate()
					nextRule = ( (Item) c ).rule;	
				} 
			}
		}
		
		AddRows(map, field);
		//beat.UnPauseInput();
		return nextRule;
	}

	public void immediate(){
		// metodo chiamato alla collisione col powerup
	}
	
	private bool IsItem(Cube c){
		//controlla se il cubo passato è un powerup
		return  c is Item;
	}
	
	private bool IsEnemy(Cube c){
		//controlla se il cubo passato è un powerup
		return c is Enemy;
	}

	protected void AddRows(LevelMap map, List<Cube> field)
	{
		List<Cube> tmpLine;
		Cube cube;
		
		try{
			tmpLine = map.GetNewLine();
			
			int x = Config.Logic.GridLength();
			int y;
			for (y=0; y< tmpLine.Count; y++) {
				cube = tmpLine [y];
				if (cube != null) {
					cube.SetPosition(x, y);
					cube.gameObject.SetActive(false);
					field.Add(cube);
					
				}
			}
		}catch(Exception){
		}
		
	}

#endregion

}
