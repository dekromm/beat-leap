using UnityEngine;
using System.Collections.Generic;
using System;



public class GameField : MonoBehaviour{
	
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
		Vector2 nextPosition;

		foreach(Cube c in field){
			nextPosition = c.Move();
			if( IsOutOfField(nextPosition) ){
				// c.Recycle(c);
			}
		}
		AddRows();

	}

	private void AddRows(){
		List<Cube> tmpLine;
		tmpLine = RtoLmap.GetNewLine();

		int x = width;
		int y;
		for(y=0; y< tmpLine.Count; y++){
			// tmpLine[y].setPosition(x,y);
			field.Add(tmpLine[y]);
		}

	}


	private void CheckCompliance(){
			
		if (RtoLmap.MapWidth() != this.height)
			throw new Exception("Map/Field height not compliant");
		// 
			
	}

	private bool IsOutOfField(Vector2 position){

		if( position.x > this.width+1)
			return true;
		if( position.y > this.height+1)
			return true;
		if( position.x < -1)
			return true;
		if( position.y < -1)
			return true;

		return false;
	}

}