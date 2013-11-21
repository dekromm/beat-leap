using UnityEngine;
using System.Collections.Generic;
using System;

public class GameField {

	private LevelMap RtoLmap;
	private int width;
	private int height;

	private List<Cube> field;

	public GameField(string track){
		field = new List<Cube>();
		try{
			// Right to Left map
			RtoLmap = new LevelMap(track);
			CheckCompliance();
		}catch(Exception){
			throw;
		}
	}

	public void StepUpdate(){

		foreach(Cube c in field){
			c.Move();
		
		}
	
	}

	private void CheckCompliance(){

		if (RtoLmap.MapWidth() != this.height)
			throw new Exception("Map/Field height not compliant");
		// 

	}


}