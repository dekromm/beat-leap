using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Rule {

	#region Beat aimed Methods

	public int getDamage(){
		return 1;
	}

	public int getMagnitude(){
		return 1;
	}
	#endregion

	#region GameField aimed Methods

	public Rule Step(List<Cube> field, LevelMap map, Beat beat){

		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			c.Move();
			
			if (beat.Collided(c)) {
				// TO-DO collisione!
				Debug.Log("COLLISIONE BOOM!");
			} else if(PowerUp(c)){
				// beat.newPowerUp(c.rule)
			}
		}

		
		AddRows(map, field);
		//		beat.UnPauseInput();
		return this;
	}

	protected bool PowerUp(Cube c){
		return false;
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

	protected void PreStep(){
		
	}

	protected void PostStep(){
	
	}

#endregion

}
