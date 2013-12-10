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

	public int getBaseMultiplier(){

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
				if(IsEnemy(c)){
					// TO-DO collisione!
					Debug.Log("COLLISIONE BOOM!");
					// beat.score - 100 ???
				} else if (IsItem(c)) {
					// ((Item) c ).rule.immediate()
					beat.NewPowerUp( ((Item) c ).rule);
					Debug.Log("COLLISIONE POWERUP!");
				} 
			}
		}
		
		AddRows(map, field);
		//		beat.UnPauseInput();
		return this;
	}

	public void immediate(){
		// metodo chiamato alla collisione col powerup
	}
	
	private bool IsItem(Cube c){
		//controlla se il cubo passato è un powerup
		return false;
	}
	
	private bool IsEnemy(Cube c){
		//controlla se il cubo passato è un powerup
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

#endregion

}
