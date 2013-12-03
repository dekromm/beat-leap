using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rule {

	private int duration;

	protected void UpdateDuration(){
		duration--;
	}

	#region Beat aimed Methods

	public float getDamage(){
		return 1;
	}

	public int getMagnitude(){
		return 1;
	}
	#endregion

	#region GameField aimed Methods

	public Rule InStep(List<Cube> field, LevelMap map, Beat beat){

		Vector2 nextPosition;
		
		List<Cube> deleteList = new List<Cube>();
		
		beat.CommitCommand();
		//	beat.PauseInput();
		foreach (Cube c in field) {
			nextPosition = c.Move();
			
			if (c.gameObject.activeSelf && IsOutOfVisibleField(nextPosition)) {
				c.gameObject.SetActive(false);
			} else if (!c.gameObject.activeSelf && !IsOutOfVisibleField(nextPosition)) {
				c.gameObject.SetActive(true);
				
			}
			
			if (Collided(c)) {
				// TO-DO collisione!
				Debug.Log("COLLISIONE BOOM!");
			} else if(PowerUp(c)){
				// beat.newPowerUp(c.rule)
			}else if (IsOutOfExternalField(nextPosition)) {
				deleteList.Add(c);
				c.Recycle();
			}
		}
		
		
		
		foreach (Cube c in deleteList) {
			field.Remove(c);
		}
		
		AddRows();

		UpdateDuration();
		//		beat.UnPauseInput();

	}

	protected bool PowerUp(Cube c){
		return false;
	}

	protected void AddRows(LevelMap map)
	{
		List<Cube> tmpLine;
		Cube cube;
		
		try{
			tmpLine = map.GetNewLine();
			
			int x = width;
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
